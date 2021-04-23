//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using CasparCg.AmcpClient.Commands.Query.Common.Info;
using CasparCg.AmcpClient.Common;
using CasparCg.AmcpClient.Utils;

namespace CasparCg.AmcpClient.Commands.Query.Common.Response
{
    public class InfoSystemCommandResponse : AmcpResponse
    {
        public string SystemInfoXml { get; private set; }
        public SystemInfo SystemInfo { get; private set; }


        internal override void ProcessData(AmcpParsedData data)
        {
            base.ProcessData(data);

            SystemInfoXml = data.Data[1];
            SystemInfo = Serializer.XmlDeserialize<SystemInfo>(data.Data[1]);
        }
    }
}