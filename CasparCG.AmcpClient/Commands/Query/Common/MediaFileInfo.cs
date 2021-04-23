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

namespace CasparCg.AmcpClient.Commands.Query.Common
{
    public class MediaFileInfo : CasparFileInfo
    {
        public MediaType MediaType { get; set; }

        /// <summary>
        /// Size in bytes
        /// </summary>
        public long Size { get; set; }

        public DateTime LastUpdate { get; set; }

        public long TotalFrames { get; set; }

        public double Fps { get; set; }

        public TimeSpan Duration { get; set; }


        public MediaFileInfo(string fullName) : base(fullName)
        {

        }

        public MediaFileInfo(string fileName, string filePath) : base(fileName, filePath)
        {

        }

        public static MediaFileInfo Parse(string data)
        {
            // "TESTPATTERNS/PAL_TEST" STILL 1658924 20151105083854 0 0/1
            // "TESTPATTERNS/PAL_TEST_A" MOVIE 873805 20151105083854 50 1/25
            // "TEST VIDEO" MOVIE 43885137 20161204041324 6972 1/25
            // "WW" AUDIO 10406536 20160917195215 0 0/1

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

                var mediaType = (MediaType)Enum.Parse(typeof(MediaType), values[0], true);
                var size = long.Parse(values[1]);
                var lastUpdate = DateTime.ParseExact(values[2], "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None);

                long totalFrames = 0;
                double fps = 0;
                int duration = 0;

                if (mediaType == MediaType.Movie)
                {
                    totalFrames = long.Parse(values[3]);

                    if (totalFrames <= 0)
                        throw new FormatException("Invalid total frames.");

                    var fpsValues = values[4].Split('/');
                    var numerator = double.Parse(fpsValues[0]);
                    var denumerator = double.Parse(fpsValues[1]);

                    fps = denumerator / numerator;
                    duration = (int)(((1.0 / fps) * totalFrames) * 1000);   // Duration in milliseconds

                    if (double.IsInfinity(fps) || fps <= 0)
                        throw new FormatException("Invalid fps.");

                    if (double.IsInfinity(duration) || duration <= 0)
                        throw new FormatException("Invalid duration.");
                }

                var mediaFileInfo = new MediaFileInfo(fullName)
                {
                    MediaType = mediaType,
                    Size = size,
                    LastUpdate = lastUpdate,
                    TotalFrames = totalFrames,
                    Fps = fps,
                    Duration = new TimeSpan(0, 0, 0, 0, duration)
                };

                return mediaFileInfo;
            }
            catch (Exception ex)
            {
                throw new FormatException("Input string was not in a correct format.", ex);
            }
        }
    }
}