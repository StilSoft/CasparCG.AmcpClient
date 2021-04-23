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

namespace CasparCg.AmcpClient.Commands.Query.Common.Info.Queue
{
    [XmlRoot(ElementName = "queue")]
    public class QueueInfo
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "queued")]
        public int Queued { get; set; }

        [XmlElement(ElementName = "running")]
        public RunningInfo Running { get; set; }
    }
}