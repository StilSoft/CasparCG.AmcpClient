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
using System.IO;
using CasparCg.AmcpClient.Utils;

namespace CasparCg.AmcpClient.Common
{
    public class CasparFileInfo
    {
        private string _fileName;
        private string _filePath;


        public string FileName
        {
            get { return _fileName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Missing file name.", nameof(FileName));

                if (!PathUtils.IsValidFileName(value))
                    throw new ArgumentException("Invalid filename.", nameof(FileName));

                _fileName = value;
            }
        }

        public string FilePath
        {
            get { return _filePath; }
            private set
            {
                if (!PathUtils.IsValidPath(value))
                    throw new ArgumentException("Invalid path.", nameof(FilePath));

                _filePath = PathUtils.WindowsToUnixPath(value);
            }
        }

        public string FullName => PathUtils.WindowsToUnixPath(Path.Combine(FilePath, FileName));


        public CasparFileInfo(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentNullException(nameof(fullName));

            FileName = Path.GetFileName(fullName);
            FilePath = Path.GetDirectoryName(fullName);
        }

        public CasparFileInfo(string fileName, string filePath)
        {
            FileName = fileName;
            FilePath = filePath;
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}