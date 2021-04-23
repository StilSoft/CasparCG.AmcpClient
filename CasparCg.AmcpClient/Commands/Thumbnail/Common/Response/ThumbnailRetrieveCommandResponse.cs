﻿//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using System;
using CasparCg.AmcpClient.Common;

namespace CasparCg.AmcpClient.Commands.Thumbnail.Common.Response
{
    public class ThumbnailRetrieveCommandResponse : AmcpResponse
    {
        private byte[] thumbnailData;

        public string ThumbnailBase64 { get; private set; }


        internal override void ProcessData(AmcpParsedData data)
        {
            base.ProcessData(data);

            this.ThumbnailBase64 = data.Data[1];
            this.thumbnailData = Convert.FromBase64String(data.Data[1]);
        }

        public byte[] GetThumbnailData()
        {
            return this.thumbnailData;
        }
    }
}