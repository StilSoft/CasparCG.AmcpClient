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

namespace CasparCg.AmcpClient.Common.EventsArgs
{
    public class ParserCompleteEventArgs<TParserResponse> : EventArgs
    {
        public TParserResponse Response { get; }


        public ParserCompleteEventArgs(TParserResponse parserResponse)
        {
            Response = parserResponse;
        }
    }
}