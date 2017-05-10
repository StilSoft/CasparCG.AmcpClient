//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using StilSoft.CasparCG.AmcpClient.Common;
using System.Collections.Generic;

namespace StilSoft.CasparCG.AmcpClient.Commands.Query.Common.Response
{
    public class FlsCommandResponse : AmcpResponse
    {
        private readonly List<FontFileInfo> _fontList = new List<FontFileInfo>();


        internal override void ProcessData(AmcpParsedData data)
        {
            base.ProcessData(data);

            for (var i = 1; i < data.Data.Count; i++)
                _fontList.Add(FontFileInfo.Parse(data.Data[i]));
        }

        public IReadOnlyList<FontFileInfo> GetFontList()
        {
            return _fontList;
        }
    }
}