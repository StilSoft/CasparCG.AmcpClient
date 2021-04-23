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
using System.Globalization;
using CasparCg.AmcpClient.Common;

namespace CasparCg.AmcpClient.Commands.Thumbnail.Common
{
    public class ThumbnailFileInfo : CasparFileInfo
    {
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// Size in bytes
        /// </summary>
        public long Size { get; set; }


        public ThumbnailFileInfo(string fullName) : base(fullName)
        {

        }

        public ThumbnailFileInfo(string fileName, string filePath) : base(fileName, filePath)
        {

        }

        public static ThumbnailFileInfo Parse(string data)
        {
            // "AMB" 20130301T124409 1149
            // "foo/bar" 20130523T234001 244

            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentNullException(nameof(data));

            try
            {
                var fullNameStartIndex = data.IndexOf('\"');
                var fullNameEndIndex = data.LastIndexOf('\"');
                var fullName = data.Substring(fullNameStartIndex + 1, fullNameEndIndex - 1);
                var remainData = data.Substring(fullNameEndIndex + 1);
                var values = remainData.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (string.IsNullOrWhiteSpace(fullName))
                    throw new FormatException("Invalid FullName.");

                var lastUpdate = DateTime.ParseExact(values[0], "yyyyMMddTHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None);
                var size = long.Parse(values[1]);

                var thumbnailFileInfo = new ThumbnailFileInfo(fullName)
                {
                    LastUpdate = lastUpdate,
                    Size = size
                };

                return thumbnailFileInfo;
            }
            catch (Exception ex)
            {
                throw new FormatException("Input string was not in a correct format.", ex);
            }
        }
    }
}