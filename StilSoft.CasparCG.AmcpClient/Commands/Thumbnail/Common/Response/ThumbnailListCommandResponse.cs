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

namespace StilSoft.CasparCG.AmcpClient.Commands.Thumbnail.Common.Response
{
    public class ThumbnailListCommandResponse : AmcpResponse
    {
        private readonly List<ThumbnailFileInfo> _thumbnailList = new List<ThumbnailFileInfo>();


        internal override void ProcessData(AmcpParsedData data)
        {
            base.ProcessData(data);

            for (var i = 1; i < data.Data.Count; i++)
                _thumbnailList.Add(ThumbnailFileInfo.Parse(data.Data[i]));
        }

        public IReadOnlyList<ThumbnailFileInfo> GetThumbnailList()
        {
            return _thumbnailList;
        }
    }
}