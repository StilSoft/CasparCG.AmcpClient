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
using System.Text;
using CasparCg.AmcpClient.Abstracts.Command;
using CasparCg.AmcpClient.Common.EventsArgs;

namespace CasparCg.AmcpClient.Common
{
    public class AmcpParser : ICommandParser<AmcpPacket, AmcpParsedData>
    {
        private enum ParserState
        {
            ExpectingHeader,
            ExpectingOneLineData,
            ExpectingMultilineData
        }

        private const string Delimiter = "\r\n";

        private readonly AmcpParsedData amcpParsedData;
        private ParserState parserState = ParserState.ExpectingHeader;
        private string remainingData;
        private bool isParsingComplete;

        public event EventHandler<ParserCompleteEventArgs<AmcpParsedData>> ParserComplete;
        public event EventHandler<ParserErrorEventArgs> ParserError;

        public AmcpPacket CommandPacket { get; set; }


        public AmcpParser()
        {
            this.amcpParsedData = new AmcpParsedData();
        }

        public void Parse(byte[] data)
        {
            try
            {
                if (this.isParsingComplete)
                {
                    Debug.WriteLine("Parsing already complete !");
                    return;
                }

                this.remainingData += Encoding.UTF8.GetString(data);

                while (true)
                {
                    int delimiterIndex = this.remainingData.IndexOf(Delimiter, StringComparison.Ordinal);

                    if (delimiterIndex == -1)
                    {
                        break;
                    }

                    string line = this.remainingData.Substring(0, delimiterIndex);

                    this.isParsingComplete = ParseLine(line);

                    //Debug.WriteLine(line);

                    if (this.isParsingComplete)
                    {
                        this.ParserComplete?.Invoke(this, new ParserCompleteEventArgs<AmcpParsedData>(this.amcpParsedData));

                        break;
                    }

                    this.remainingData = this.remainingData.Substring(delimiterIndex + Delimiter.Length);
                }
            }
            catch (Exception ex)
            {
                this.ParserError?.Invoke(this, new ParserErrorEventArgs(ex));
            }
        }

        private bool ParseLine(string line)
        {
            switch (this.parserState)
            {
                case ParserState.ExpectingHeader:
                    return ParseHeader(line);
                case ParserState.ExpectingOneLineData:
                    return ParseOneLineData(line);
                case ParserState.ExpectingMultilineData:
                    return ParseMultiLineData(line);
            }

            return false;
        }

        private bool ParseHeader(string line)
        {
            this.amcpParsedData.Code = AmcpReturnCode.Unknown;

            string[] values = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            byte index = 0;

            if (this.CommandPacket.IncludePacketId)
            {
                // "RES e52e0080-9dfc-4c1a-942e-549bfa48d143 200 CLS OK"
                if (values.Length < 4 ||
                    !values[index++].Equals("RES") ||
                    !this.CommandPacket.PacketId.Equals(values[index++]))
                {
                    //Debug.WriteLine("Invalid header");
                    return false;
                }
            }
            else
            {
                // "200 CLS OK"
                if (values.Length < 2 ||
                    !Equals(this.CommandPacket.CommandName, values[1])
                ) // TODO return code 400 and 500 not contain command name ???
                {
                    //Debug.WriteLine("Invalid header");
                    return false;
                }
            }

            if (!int.TryParse(values[index], out int headerCode) ||
                !Enum.IsDefined(typeof(AmcpReturnCode), headerCode) ||
                (AmcpReturnCode)headerCode == AmcpReturnCode.Unknown)
            {
                //Debug.WriteLine("Invalid header code");
                return false;
            }

            this.amcpParsedData.Data.Add(line);
            this.amcpParsedData.Code = (AmcpReturnCode)headerCode;

            switch (this.amcpParsedData.Code)
            {
                // Parsing complete (no additional data expected)
                case AmcpReturnCode.Info:
                case AmcpReturnCode.Ok:
                case AmcpReturnCode.InvalidChannel:
                case AmcpReturnCode.ParameterMissing:
                case AmcpReturnCode.ParameterIllegal:
                case AmcpReturnCode.MediaFileNotFound:
                case AmcpReturnCode.InternalServerError:
                case AmcpReturnCode.MediaFileUnreadible:
                case AmcpReturnCode.AccessError:
                    return true;

                // Expecting one line data
                case AmcpReturnCode.InfoData:
                case AmcpReturnCode.OkData:
                case AmcpReturnCode.CommandUnknownData:
                case AmcpReturnCode.InternalServerErrorData:
                    this.parserState = ParserState.ExpectingOneLineData;
                    break;

                // Expecting multi line data    
                case AmcpReturnCode.OkMultiData:
                    this.parserState = ParserState.ExpectingMultilineData;
                    break;
            }

            return false;
        }

        private bool ParseOneLineData(string dataLine)
        {
            this.amcpParsedData.Data.Add(dataLine);

            return true;
        }

        private bool ParseMultiLineData(string dataLine)
        {
            if (dataLine.Length == 0)
            {
                return true;
            }

            this.amcpParsedData.Data.Add(dataLine);

            return false;
        }
    }
}