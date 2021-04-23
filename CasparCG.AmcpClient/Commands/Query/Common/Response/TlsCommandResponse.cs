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
using CasparCg.AmcpClient.Common;

namespace CasparCg.AmcpClient.Commands.Query.Common.Response
{
    public class TlsCommandResponse : AmcpResponse
    {
        private readonly List<TemplateFileInfo> _templateList = new List<TemplateFileInfo>();


        internal override void ProcessData(AmcpParsedData data)
        {
            base.ProcessData(data);

            for (var i = 1; i < data.Data.Count; i++)
                _templateList.Add(TemplateFileInfo.Parse(data.Data[i]));
        }

        public IReadOnlyList<TemplateFileInfo> GetTemplateList(TemplateType? templateType = null)
        {
            var templateListTmp = new List<TemplateFileInfo>();

            foreach (var templateFileInfo in _templateList)
            {
                if (templateType.HasValue)
                {
                    if (templateFileInfo.TemplateType == templateType)
                        templateListTmp.Add(templateFileInfo);
                }
                else
                {
                    templateListTmp.Add(templateFileInfo);
                }
            }

            return templateListTmp;
        }
    }
}