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

        private readonly AmcpParsedData _amcpParsedData;
        private ParserState _parserState = ParserState.ExpectingHeader;
        private string _remainingData;
        private bool _isParsingComplete;

        public AmcpPacket CommandPacket { get; set; }

        public event EventHandler<ParserCompleteEventArgs<AmcpParsedData>> ParserComplete;
        public event EventHandler<ParserErrorEventArgs> ParserError;


        public AmcpParser()
        {
            _amcpParsedData = new AmcpParsedData();
        }

        public void Parse(byte[] data)
        {
            try
            {
                if (_isParsingComplete)
                {
                    Debug.WriteLine("Parsing already complete !");
                    return;
                }

                _remainingData += Encoding.UTF8.GetString(data);

                while (true)
                {
                    var delimiterIndex = _remainingData.IndexOf(Delimiter, StringComparison.Ordinal);

                    if (delimiterIndex == -1)
                        break;

                    var line = _remainingData.Substring(0, delimiterIndex);

                    _isParsingComplete = ParseLine(line);

                    //Debug.WriteLine(line);

                    if (_isParsingComplete)
                    {
                        ParserComplete?.Invoke(this, new ParserCompleteEventArgs<AmcpParsedData>(_amcpParsedData));

                        break;
                    }

                    _remainingData = _remainingData.Substring(delimiterIndex + Delimiter.Length);
                }
            }
            catch (Exception ex)
            {
                ParserError?.Invoke(this, new ParserErrorEventArgs(ex));
            }
        }

        private bool ParseLine(string line)
        {
            switch (_parserState)
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
            _amcpParsedData.Code = AmcpReturnCode.Unknown;

            var values = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            byte index = 0;

            if (CommandPacket.IncludePacketId)
            {
                // "RES e52e0080-9dfc-4c1a-942e-549bfa48d143 200 CLS OK"
                if (values.Length < 4 ||
                    !values[index++].Equals("RES") ||
                    !CommandPacket.PacketId.Equals(values[index++]))
                {
                    //Debug.WriteLine("Invalid header");
                    return false;
                }
            }
            else
            {
                // "200 CLS OK"
                if (values.Length < 2 ||
                    !Equals(CommandPacket.CommandName, values[1]))  // TODO return code 400 and 500 not contain command name ???
                {
                    //Debug.WriteLine("Invalid header");
                    return false;
                }
            }

            int headerCode;

            if (!int.TryParse(values[index], out headerCode) ||
                !Enum.IsDefined(typeof(AmcpReturnCode), headerCode) ||
                (AmcpReturnCode)headerCode == AmcpReturnCode.Unknown)
            {
                //Debug.WriteLine("Invalid header code");
                return false;
            }

            _amcpParsedData.Data.Add(line);
            _amcpParsedData.Code = (AmcpReturnCode)headerCode;

            switch (_amcpParsedData.Code)
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
                    _parserState = ParserState.ExpectingOneLineData;
                    break;

                // Expecting multi line data    
                case AmcpReturnCode.OkMultiData:
                    _parserState = ParserState.ExpectingMultilineData;
                    break;
            }

            return false;
        }

        private bool ParseOneLineData(string dataLine)
        {
            _amcpParsedData.Data.Add(dataLine);

            return true;
        }

        private bool ParseMultiLineData(string dataLine)
        {
            if (dataLine.Length == 0)
                return true;

            _amcpParsedData.Data.Add(dataLine);

            return false;
        }
    }
}