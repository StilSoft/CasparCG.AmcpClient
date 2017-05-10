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
using StilSoft.CasparCG.AmcpClient.Utils;

namespace StilSoft.CasparCG.AmcpClient.Commands.Query.Common.Response
{
    public class InfoLayerDelayCommandResponse : AmcpResponse
    {
        public string LayerDelayInfoXml { get; private set; }
        public LayerDelayInfo LayerDelayInfo { get; private set; }


        internal override void ProcessData(AmcpParsedData data)
        {
            base.ProcessData(data);

            LayerDelayInfoXml = data.Data[1];
            LayerDelayInfo = Serializer.XmlDeserialize<LayerDelayInfo>(data.Data[1]);
        }
    }
}