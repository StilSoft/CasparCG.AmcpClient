//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using CasparCg.AmcpClient.Commands.Query.Common.Info.Template;
using CasparCg.AmcpClient.Common;
using CasparCg.AmcpClient.Utils;

namespace CasparCg.AmcpClient.Commands.Query.Common.Response
{
    public class InfoTemplateCommandResponse : AmcpResponse
    {
        public string TemplateInfoXml { get; private set; }
        public TemplateInfo TemplateInfo { get; private set; }


        internal override void ProcessData(AmcpParsedData data)
        {
            base.ProcessData(data);

            TemplateInfoXml = data.Data[1];
            TemplateInfo = Serializer.XmlDeserialize<TemplateInfo>(data.Data[1]);
        }
    }
}