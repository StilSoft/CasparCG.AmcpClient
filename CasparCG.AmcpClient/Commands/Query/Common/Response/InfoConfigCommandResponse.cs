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
    public class InfoConfigCommandResponse : AmcpResponse
    {
        public string ConfigInfoXml { get; private set; }
        public ConfigInfo ConfigInfo { get; private set; }


        internal override void ProcessData(AmcpParsedData data)
        {
            base.ProcessData(data);

            ConfigInfoXml = data.Data[1];
            ConfigInfo = Serializer.XmlDeserialize<ConfigInfo>(data.Data[1]);
        }
    }
}