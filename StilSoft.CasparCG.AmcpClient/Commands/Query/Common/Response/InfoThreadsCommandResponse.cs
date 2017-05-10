//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using StilSoft.CasparCG.AmcpClient.Commands.Query.Common.Info;
using StilSoft.CasparCG.AmcpClient.Common;
using System.Collections.Generic;

namespace StilSoft.CasparCG.AmcpClient.Commands.Query.Common.Response
{
    public class InfoThreadsCommandResponse : AmcpResponse
    {
        private readonly List<ThreadInfo> _threadList = new List<ThreadInfo>();


        internal override void ProcessData(AmcpParsedData data)
        {
            base.ProcessData(data);

            for (var i = 1; i < data.Data.Count; i++)
                _threadList.Add(ThreadInfo.Parse(data.Data[i]));
        }

        public IReadOnlyList<ThreadInfo> GetThreadList()
        {
            return _threadList;
        }
    }
}