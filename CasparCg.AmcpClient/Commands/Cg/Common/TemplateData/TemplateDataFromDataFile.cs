//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using CasparCg.AmcpClient.Common;

namespace CasparCg.AmcpClient.Commands.Cg.Common.TemplateData
{
    public class TemplateDataFromDataFile : AbstractTemplateData
    {
        private readonly CasparFileInfo fileInfo;


        public TemplateDataFromDataFile(CasparFileInfo fileInfo)
        {
            this.fileInfo = fileInfo;
        }

        public override string ToString()
        {
            return this.fileInfo.FullName;
        }
    }
}