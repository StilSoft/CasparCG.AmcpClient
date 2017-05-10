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

namespace StilSoft.CasparCG.AmcpClient.Commands.Query.Common.Info.Template
{
    [XmlRoot(ElementName = "component")]
    public class ComponentInfo
    {
        [XmlElement(ElementName = "property")]
        public List<PropertyInfo> Properties { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }
}