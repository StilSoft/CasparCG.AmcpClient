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
    // TODO Create producers classes based on type (different type of producers have different properties)
    [XmlRoot(ElementName = "producer")]
    public class ProducerInfo
    {
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }

        // TODO casparcg returns wrong path separator. Change string to CasparFileInfo ??
        [XmlElement(ElementName = "filename")]
        public string FileName { get; set; }

        [XmlElement(ElementName = "width")]
        public int Width { get; set; }

        [XmlElement(ElementName = "height")]
        public int Height { get; set; }

        [XmlElement(ElementName = "progressive")]
        public bool Progressive { get; set; }

        [XmlElement(ElementName = "fps")]
        public double Fps { get; set; }

        [XmlElement(ElementName = "loop")]
        public bool Loop { get; set; }

        [XmlElement(ElementName = "frame-number")]
        public long FrameNumber { get; set; }

        [XmlElement(ElementName = "nb-frames")]
        public long NbFrames { get; set; }

        [XmlElement(ElementName = "file-frame-number")]
        public long FileFrameNumber { get; set; }

        [XmlElement(ElementName = "file-nb-frames")]
        public long FileNbFrames { get; set; }
    }
}