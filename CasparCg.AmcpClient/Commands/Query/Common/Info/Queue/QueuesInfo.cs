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

namespace CasparCg.AmcpClient.Commands.Query.Common.Info.Queue
{
    [XmlRoot(ElementName = "queues")]
    public class QueuesInfo
    {
        [XmlElement(ElementName = "queue")]
        public List<QueueInfo> Queues { get; set; }
    }
}