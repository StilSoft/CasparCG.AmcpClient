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
    public class InfoChannelDelayCommandResponse : AmcpResponse
    {
        public string ChannelDelayInfoXml { get; private set; }
        public ChannelDelayInfo ChannelDelayInfo { get; private set; }


        internal override void ProcessData(AmcpParsedData data)
        {
            base.ProcessData(data);

            ChannelDelayInfoXml = data.Data[1];
            ChannelDelayInfo = Serializer.XmlDeserialize<ChannelDelayInfo>(data.Data[1]);
        }
    }
}