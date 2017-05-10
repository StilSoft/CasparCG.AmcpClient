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

namespace StilSoft.CasparCG.AmcpClient.Commands.Query.Common.Info.Channel
{
    [XmlRoot(ElementName = "foreground")]
    public class ForegroundInfo
    {
        [XmlElement(ElementName = "producer")]
        public ProducerInfo Producer { get; set; }
    }
}