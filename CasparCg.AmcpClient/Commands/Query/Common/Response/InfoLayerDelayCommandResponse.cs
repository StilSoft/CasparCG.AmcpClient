﻿//////////////////////////////////////////////////////////////////////////////////
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
    public class InfoLayerDelayCommandResponse : AmcpResponse
    {
        public string LayerDelayInfoXml { get; private set; }
        public LayerDelayInfo LayerDelayInfo { get; private set; }


        internal override void ProcessData(AmcpParsedData data)
        {
            base.ProcessData(data);

            this.LayerDelayInfoXml = data.Data[1];
            this.LayerDelayInfo = Serializer.XmlDeserialize<LayerDelayInfo>(data.Data[1]);
        }
    }
}