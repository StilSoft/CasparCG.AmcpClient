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
    public class TemplateFileInfo : CasparFileInfo
    {
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// Size in bytes
        /// </summary>
        public long Size { get; set; }

        public TemplateType TemplateType { get; set; }


        public TemplateFileInfo(string fullName) : base(fullName)
        {

        }

        public TemplateFileInfo(string fileName, string filePath) : base(fileName, filePath)
        {

        }

        public static TemplateFileInfo Parse(string data)
        {
            // "NOTA PSD" 981185 20170112161836 psd
            // "NTSC-TEST-30" 37275 20151105083859 flash
            // "NTSC-TEST-60" 37274 20151105083859 flash
            // "scene/crawler/CRAWLER" 3189 20170308171222 scene
            // "scene/diagram/BAR" 1595 20170214175017 scene
            // "scene/diagram/DIAGRAM" 3871 20170214175017 scene

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

                var size = long.Parse(values[0]);
                var lastUpdate = DateTime.ParseExact(values[1], "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None);
                var templateType = (TemplateType)Enum.Parse(typeof(TemplateType), values[2], true);

                var templateFileInfo = new TemplateFileInfo(fullName)
                {
                    Size = size,
                    LastUpdate = lastUpdate,
                    TemplateType = templateType
                };

                return templateFileInfo;
            }
            catch (Exception ex)
            {
                throw new FormatException("Input string was not in a correct format.", ex);
            }
        }
    }
}