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
    public class FlsCommandResponse : AmcpResponse
    {
        private readonly List<FontFileInfo> fontList = new List<FontFileInfo>();


        internal override void ProcessData(AmcpParsedData data)
        {
            base.ProcessData(data);

            for (int i = 1; i < data.Data.Count; i++)
            {
                this.fontList.Add(FontFileInfo.Parse(data.Data[i]));
            }
        }

        public IReadOnlyList<FontFileInfo> GetFontList()
        {
            return this.fontList;
        }
    }
}