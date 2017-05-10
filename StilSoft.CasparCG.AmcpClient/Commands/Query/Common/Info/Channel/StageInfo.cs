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

namespace StilSoft.CasparCG.AmcpClient.Commands.Query.Common.Info.Channel
{
    [XmlRoot(ElementName = "stage")]
    public class StageInfo
    {
        [XmlArray("layers")]
        [XmlArrayItem("layer")]
        public List<LayerInfo> Layers { get; set; } = new List<LayerInfo>();
    }
}