//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using CasparCg.AmcpClient.Commands.Query.Common.Info.Queue;
using CasparCg.AmcpClient.Common;
using CasparCg.AmcpClient.Utils;

namespace CasparCg.AmcpClient.Commands.Query.Common.Response
{
    public class InfoQueuesCommandResponse : AmcpResponse
    {
        public string QueuesInfoXml { get; private set; }
        public QueuesInfo QueuesInfo { get; private set; }


        internal override void ProcessData(AmcpParsedData data)
        {
            base.ProcessData(data);

            QueuesInfoXml = data.Data[1];
            QueuesInfo = Serializer.XmlDeserialize<QueuesInfo>(data.Data[1]);
        }
    }
}