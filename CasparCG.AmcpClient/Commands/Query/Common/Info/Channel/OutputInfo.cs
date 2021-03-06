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

namespace CasparCg.AmcpClient.Commands.Query.Common.Info.Channel
{
    [XmlRoot(ElementName = "output")]
    public class OutputInfo
    {
        [XmlArray("consumers")]
        [XmlArrayItem("consumer")]
        public List<ConsumerInfo> Consumers { get; set; } = new List<ConsumerInfo>();
    }
}