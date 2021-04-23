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
    [XmlRoot(ElementName = "layer")]
    public class LayerInfo
    {
        [XmlElement(ElementName = "auto_delta")]
        public string AutoDelta { get; set; }

        [XmlElement(ElementName = "frame-number")]
        public long FrameNumber { get; set; }

        [XmlElement(ElementName = "nb_frames")]
        public long NbFrames { get; set; }

        [XmlElement(ElementName = "frames-left")]
        public long FramesLeft { get; set; }

        [XmlElement(ElementName = "frame-age")]
        public long FrameAge { get; set; }

        [XmlElement(ElementName = "foreground")]
        public ForegroundInfo Foreground { get; set; }

        [XmlElement(ElementName = "background")]
        public BackgroundInfo Background { get; set; }

        [XmlElement(ElementName = "index")]
        public string Index { get; set; }
    }
}