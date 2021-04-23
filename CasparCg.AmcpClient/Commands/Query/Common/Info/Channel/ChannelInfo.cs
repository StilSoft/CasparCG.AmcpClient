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
using CasparCg.AmcpClient.Common.Enums;

namespace CasparCg.AmcpClient.Commands.Query.Common.Info.Channel
{
    // TODO parse method in all info classes ???
    [XmlRoot(ElementName = "channel")]
    public class ChannelInfo
    {
        [XmlElement(ElementName = "video-mode")]
        public VideoMode VideoMode { get; set; }

        // TODO return "AudioLayout" enum (parse string to enum)
        [XmlElement(ElementName = "audio-channel-layout")]
        public string AudioChannelLayout { get; set; }

        [XmlElement(ElementName = "stage")]
        public StageInfo Stage { get; set; }

        [XmlElement(ElementName = "mixer")]
        public MixerInfo Mixer { get; set; }

        [XmlElement(ElementName = "output")]
        public OutputInfo Output { get; set; }

        [XmlElement(ElementName = "index")]
        public int Index { get; set; }
    }
}