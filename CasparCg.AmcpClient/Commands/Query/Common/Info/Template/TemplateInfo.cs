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

namespace CasparCg.AmcpClient.Commands.Query.Common.Info.Template
{
    [XmlRoot(ElementName = "template")]
    public class TemplateInfo
    {
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }

        [XmlAttribute(AttributeName = "authorName")]
        public string AuthorName { get; set; }

        [XmlAttribute(AttributeName = "authorEmail")]
        public string AuthorEmail { get; set; }

        [XmlAttribute(AttributeName = "templateInfo")]
        public string TemplateInformation { get; set; }

        [XmlAttribute(AttributeName = "originalWidth")]
        public int OriginalWidth { get; set; }

        [XmlAttribute(AttributeName = "originalHeight")]
        public int OriginalHeight { get; set; }

        [XmlAttribute(AttributeName = "originalFrameRate")]
        public double OriginalFrameRate { get; set; }

        [XmlArray("components")]
        [XmlArrayItem("component")]
        public List<ComponentInfo> Components { get; set; }

        [XmlArray("keyframes")]
        [XmlArrayItem("keyframe")]
        public List<KeyFrameInfo> KeyFrames { get; set; }

        [XmlArray("instances")]
        [XmlArrayItem("instance")]
        public List<InstanceInfo> Instances { get; set; }

        [XmlArray("parameters")]
        [XmlArrayItem("parameter")]
        public List<ParameterInfo> Parameters { get; set; }
    }
}