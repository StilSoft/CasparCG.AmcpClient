//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CasparCg.AmcpClient.Utils
{
    public static class Serializer
    {
        public static string XmlSerialize<T>(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true }))
                {
                    var xmlNamespace = new XmlSerializerNamespaces();
                    xmlNamespace.Add("", "");
                    new XmlSerializer(typeof(T)).Serialize(xmlWriter, obj, xmlNamespace);
                    return stringWriter.ToString();
                }
            }
        }

        public static T XmlDeserialize<T>(string xmlData)
        {
            using (var textReader = new StringReader(xmlData))
            {
                return (T)new XmlSerializer(typeof(T)).Deserialize(textReader);
            }
        }
    }
}
