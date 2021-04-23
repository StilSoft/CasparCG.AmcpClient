//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using System.Collections.Generic;
using System.Xml.Serialization;
using CasparCg.AmcpClient.Commands.Query.Common.Info.Channel;

namespace CasparCg.AmcpClient.Commands.Query.Common.Info
{
    [XmlRoot(ElementName = "channels")]
    public class ServerInfo
    {
        [XmlElement(ElementName = "channel")]
        public List<ChannelInfo> Channels { get; set; }
    }
}