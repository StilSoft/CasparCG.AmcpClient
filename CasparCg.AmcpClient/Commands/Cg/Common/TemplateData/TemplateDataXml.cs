//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace CasparCg.AmcpClient.Commands.Cg.Common.TemplateData
{
    public class TemplateDataXml : AbstractTemplateData
    {
        private readonly List<DataPair> dataPairs;


        public TemplateDataXml()
        {
            this.dataPairs = new List<DataPair>();
        }

        public void Add(DataPair dataPair)
        {
            if (this.dataPairs.Find(name => name.Name == dataPair.Name) != null)
            {
                throw new ArgumentException("Data pair with same name already exists.", nameof(dataPair));
            }

            this.dataPairs.Add(dataPair);
        }

        public void Remove(DataPair dataPair)
        {
            this.dataPairs.Remove(dataPair);
        }

        public void Remove(string dataPairName)
        {
            DataPair dataPair = this.dataPairs.Find(name => name.Name == dataPairName);

            if (dataPair == null)
            {
                return;
            }

            this.dataPairs.Remove(dataPair);
        }

        public void Clear()
        {
            this.dataPairs.Clear();
        }

        public DataPair Get(string dataPairName)
        {
            DataPair dataPair = this.dataPairs.Find(name => name.Name == dataPairName);

            return dataPair ?? throw new ArgumentException("Data pair with the requested name is not found.", nameof(dataPairName));
        }

        public IReadOnlyList<DataPair> GetAll()
        {
            return this.dataPairs;
        }

        public TemplateDataXml Parse(string xmlData)
        {
            // TODO implement parser
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            //<templateData>
            //    <componentData id="f0">
            //        <data id="text" value="Niklas P Andersson" /> </componentData>
            //    <componentData id="f1">
            //        <data id="text" value="Developer" />
            //    </componentData>
            //    <componentData id="f2">
            //        <data id="text" value="Providing an example" />
            //    </componentData>
            //</templateData>

            using (var stringWriter = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(stringWriter,
                    new XmlWriterSettings { OmitXmlDeclaration = true, Indent = false }))
                {
                    xmlWriter.WriteStartElement("templateData");

                    foreach (DataPair dataPair in this.dataPairs)
                    {
                        xmlWriter.WriteStartElement("componentData");
                        xmlWriter.WriteAttributeString("id", dataPair.Name);

                        xmlWriter.WriteStartElement("data");
                        xmlWriter.WriteAttributeString("id", "text");
                        xmlWriter.WriteAttributeString("value", dataPair.Value);
                        xmlWriter.WriteEndElement();

                        xmlWriter.WriteEndElement();
                    }

                    xmlWriter.WriteEndElement();
                }

                return stringWriter.ToString();
            }
        }
    }
}