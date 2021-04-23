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

namespace CasparCg.AmcpClient.Commands.Query.Common.Info.Channel
{
    // TODO Create consumers classes based on type (different type of consumers have different properties)
    [XmlRoot(ElementName = "consumer")]
    public class ConsumerInfo
    {
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "index")]
        public int Index { get; set; }

        [XmlElement(ElementName = "key-only")]
        public bool KeyOnly { get; set; }

        [XmlElement(ElementName = "windowed")]
        public bool Windowed { get; set; }

        [XmlElement(ElementName = "auto-deinterlace")]
        public bool AutoDeinterlace { get; set; }

        [XmlElement(ElementName = "vsync")]
        public bool Vsync { get; set; }
    }
}