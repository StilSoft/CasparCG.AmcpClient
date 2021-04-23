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

namespace CasparCg.AmcpClient.Commands.Thumbnail.Common.Response
{
    public class ThumbnailListCommandResponse : AmcpResponse
    {
        private readonly List<ThumbnailFileInfo> thumbnailList = new List<ThumbnailFileInfo>();


        internal override void ProcessData(AmcpParsedData data)
        {
            base.ProcessData(data);

            for (int i = 1; i < data.Data.Count; i++)
            {
                this.thumbnailList.Add(ThumbnailFileInfo.Parse(data.Data[i]));
            }
        }

        public IReadOnlyList<ThumbnailFileInfo> GetThumbnailList()
        {
            return this.thumbnailList;
        }
    }
}