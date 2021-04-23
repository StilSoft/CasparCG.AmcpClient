//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using CasparCg.AmcpClient.Commands.Query.Common.Info.Channel;
using CasparCg.AmcpClient.Common;
using CasparCg.AmcpClient.Utils;

namespace CasparCg.AmcpClient.Commands.Query.Common.Response
{
    public class InfoChannelCommandResponse : AmcpResponse
    {
        public string ChannelInfoXml { get; private set; }
        public ChannelInfo ChannelInfo { get; private set; }


        internal override void ProcessData(AmcpParsedData data)
        {
            base.ProcessData(data);

            ChannelInfoXml = data.Data[1];
            ChannelInfo = Serializer.XmlDeserialize<ChannelInfo>(data.Data[1]);
        }
    }
}