//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using System.Xml.Serialization;

namespace CasparCg.AmcpClient.Commands.Query.Common.Info.Template
{
    [XmlRoot(ElementName = "instance")]
    public class InstanceInfo
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }
}