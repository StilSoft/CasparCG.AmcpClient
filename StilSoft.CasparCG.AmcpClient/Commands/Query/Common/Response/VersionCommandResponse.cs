//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using StilSoft.CasparCG.AmcpClient.Common;
using System;
using System.Text.RegularExpressions;

namespace StilSoft.CasparCG.AmcpClient.Commands.Query.Common.Response
{
    public class VersionCommandResponse : AmcpResponse
    {
        public Version Version { get; private set; }


        internal override void ProcessData(AmcpParsedData data)
        {
            base.ProcessData(data);

            Version = Version.Parse(Regex.Match(data.Data[1], @"\d+(?:\.\d+)+").Value);
        }
    }
}