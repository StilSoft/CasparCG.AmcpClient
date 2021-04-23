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

namespace CasparCg.AmcpClient.Commands.Data.Common
{
    public class DataFileInfo : CasparFileInfo
    {
        public DataFileInfo(string fullName) : base(fullName)
        {

        }

        public DataFileInfo(string fileName, string filePath) : base(fileName, filePath)
        {

        }

        public static DataFileInfo Parse(string data)
        {
            // file1
            // file2
            // directory1/file1
            // directory1/file2

            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentNullException(nameof(data));

            try
            {
                return new DataFileInfo(data);
            }
            catch (Exception ex)
            {
                throw new FormatException("Input string was not in a correct format", ex);
            }
        }
    }
}