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
using CasparCg.AmcpClient.Common;

namespace CasparCg.AmcpClient.Commands.Query.Common
{
    public class FontFileInfo : CasparFileInfo
    {
        public string FontName { get; set; }


        public FontFileInfo(string fullName) : base(fullName)
        {

        }

        public FontFileInfo(string fileName, string filePath) : base(fileName, filePath)
        {

        }

        public static FontFileInfo Parse(string data)
        {
            // "Verdana" "verdana.ttf"
            // "Verdana-Bold" "verdanab.ttf"
            // "Verdana-BoldItalic" "verdanaz.ttf"
            // "Verdana-Italic" "verdanai.ttf"

            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentNullException(nameof(data));

            try
            {
                var values = data.Split(' ');
                var fontName = values[0].Replace("\"", "");
                var fullName = values[1].Replace("\"", "");

                if (string.IsNullOrWhiteSpace(fontName))
                    throw new FormatException("Invalid 'Font Name'.");

                if (string.IsNullOrWhiteSpace(fullName))
                    throw new FormatException("Invalid 'Full Name'.");

                var fontFileInfo = new FontFileInfo(fullName) { FontName = fontName };

                return fontFileInfo;
            }
            catch (Exception ex)
            {
                throw new FormatException("Input string was not in a correct format.", ex);
            }
        }
    }
}