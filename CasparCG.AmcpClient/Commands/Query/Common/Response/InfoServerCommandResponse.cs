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
    public class InfoServerCommandResponse : AmcpResponse
    {
        public string ServerInfoXml { get; private set; }
        public ServerInfo ServerInfo { get; private set; }


        internal override void ProcessData(AmcpParsedData data)
        {
            base.ProcessData(data);

            ServerInfoXml = data.Data[1];
            ServerInfo = Serializer.XmlDeserialize<ServerInfo>(data.Data[1]);
        }
    }
}