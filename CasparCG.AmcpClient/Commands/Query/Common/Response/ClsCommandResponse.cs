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
    public class ClsCommandResponse : AmcpResponse
    {
        private readonly List<MediaFileInfo> _mediaList = new List<MediaFileInfo>();


        internal override void ProcessData(AmcpParsedData data)
        {
            base.ProcessData(data);

            for (var i = 1; i < data.Data.Count; i++)
                _mediaList.Add(MediaFileInfo.Parse(data.Data[i]));
        }

        public IReadOnlyList<MediaFileInfo> GetMediaList(MediaType? mediaType = null)
        {
            var mediaListTmp = new List<MediaFileInfo>();

            foreach (var mediaFileInfo in _mediaList)
            {
                if (mediaType.HasValue)
                {
                    if (mediaFileInfo.MediaType == mediaType)
                        mediaListTmp.Add(mediaFileInfo);
                }
                else
                {
                    mediaListTmp.Add(mediaFileInfo);
                }
            }

            return mediaListTmp;
        }
    }
}