//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using System.Collections.Generic;

namespace CasparCg.AmcpClient.Common
{
    public class AmcpParsedData
    {
        public AmcpReturnCode Code { get; internal set; }
        public List<string> Data { get; internal set; }

        public AmcpParsedData()
        {
            Code = AmcpReturnCode.Unknown;
            Data = new List<string>();
        }
    }
}