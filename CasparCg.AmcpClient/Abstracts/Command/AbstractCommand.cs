//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using System;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataReceivedEventArgs = CasparCg.AmcpClient.Common.EventsArgs.DataReceivedEventArgs;

namespace CasparCg.AmcpClient.Abstracts.Command
{
    public abstract class AbstractCommand<TPacket, TParser, TParserResponse, TResponse>
        where TPacket : ICommandPacket
        where TParser : ICommandParser<TPacket, TParserResponse>, new()
        where TResponse : AbstractCommandResponse<TParserResponse>, new()
    {
        private object lockExecute;

        internal ICommandConnection Connection { get; set; }
        public int ResponseTimeout { get; set; } = 2000;

        protected abstract TPacket GetPacket();


        public Task<TResponse> ExecuteAsync(ICommandConnection connection)
        {
            this.Connection = connection;

            var commandClone = (AbstractCommand<TPacket, TParser, TParserResponse, TResponse>)MemberwiseClone();

            return Task.Run(() => commandClone.Execute(connection));
        }

        public TResponse Execute(ICommandConnection connection)
        {
            if (this.lockExecute == null)
            {
                this.lockExecute = new object();
            }

            lock (this.lockExecute)
            {
                this.Connection = connection;

                if (connection == null)
                {
                    throw new ArgumentNullException(nameof(connection), "Command connection cannot be null.");
                }

                TPacket packet = GetPacket();
                var parser = new TParser();
                var response = new TResponse();
                var parserCompleteEvent = new AutoResetEvent(false);

                parser.CommandPacket = packet;

                var parserResponse = default(TParserResponse);
                parser.ParserComplete += (s, e) =>
                {
                    Debug.WriteLine("Parser complete");
                    parserResponse = e.Response;
                    parserCompleteEvent.Set();
                };

                Exception parserException = null;
                parser.ParserError += (s, e) =>
                {
                    Debug.WriteLine("Parser error");
                    parserException = e.Exception;
                    parserCompleteEvent.Set();
                };

                void DataReceivedEventHandler(object s, DataReceivedEventArgs e)
                {
                    parser.Parse(e.Data);
                }

                if (this.ResponseTimeout > 0)
                {
                    Debug.WriteLine("Attach parser");
                    connection.DataReceived += DataReceivedEventHandler;
                }

                try
                {
                    Debug.WriteLine("Send: " + Encoding.UTF8.GetString(packet.Data).Replace("\r\n", ""));

                    connection.Send(packet.Data);

                    // If response timeout is 0, do not wait parser to complete 
                    if (this.ResponseTimeout > 0)
                    {
                        // Wait parser to complete
                        bool isParserComplete = parserCompleteEvent.WaitOne(this.ResponseTimeout);

                        Debug.WriteLine("Deattach parser");
                        connection.DataReceived -= DataReceivedEventHandler;

                        if (parserException != null)
                        {
                            ExceptionDispatchInfo.Capture(parserException).Throw();
                        }

                        if (!isParserComplete)
                        {
                            throw new TimeoutException("Command response timeout.");
                        }

                        if (parserResponse != null)
                        {
                            response.ProcessData(parserResponse);
                        }
                    }
                }
                catch
                {
                    if (this.ResponseTimeout > 0)
                    {
                        Debug.WriteLine("Deattach parser");
                        connection.DataReceived -= DataReceivedEventHandler;
                    }

                    throw;
                }

                return response;
            }
        }
    }
}