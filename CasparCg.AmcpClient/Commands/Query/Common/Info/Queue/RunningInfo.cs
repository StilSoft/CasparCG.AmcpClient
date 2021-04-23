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
    [XmlRoot(ElementName = "running")]
    public class RunningInfo
    {
        [XmlElement(ElementName = "command")]
        public string Command { get; set; }

        [XmlElement(ElementName = "params")]
        public string Params { get; set; }

        [XmlElement(ElementName = "elapsed")]
        public long Elapsed { get; set; }
    }
}