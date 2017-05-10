//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using StilSoft.CasparCG.AmcpClient.Common.EventsArgs;
using System;

namespace StilSoft.CasparCG.AmcpClient.Abstracts.Command
{
    public interface ICommandParser<TCommandPacket, TParserResponse>
        where TCommandPacket : ICommandPacket 
    {
        event EventHandler<ParserCompleteEventArgs<TParserResponse>> ParserComplete;
        event EventHandler<ParserErrorEventArgs> ParserError;
        void Parse(byte[] data);
        TCommandPacket CommandPacket { get; set; }
    }
}