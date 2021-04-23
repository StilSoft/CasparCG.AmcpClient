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
        private string fileName;
        private string filePath;


        public string FileName
        {
            get => this.fileName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Missing file name.", nameof(this.FileName));
                }

                if (!PathUtils.IsValidFileName(value))
                {
                    throw new ArgumentException("Invalid filename.", nameof(this.FileName));
                }

                this.fileName = value;
            }
        }

        public string FilePath
        {
            get => this.filePath;
            private set
            {
                if (!PathUtils.IsValidPath(value))
                {
                    throw new ArgumentException("Invalid path.", nameof(this.FilePath));
                }

                this.filePath = PathUtils.WindowsToUnixPath(value);
            }
        }

        public string FullName => PathUtils.WindowsToUnixPath(Path.Combine(this.FilePath, this.FileName));


        public CasparFileInfo(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentNullException(nameof(fullName));
            }

            this.FileName = Path.GetFileName(fullName);
            this.FilePath = Path.GetDirectoryName(fullName);
        }

        public CasparFileInfo(string fileName, string filePath)
        {
            this.FileName = fileName;
            this.FilePath = filePath;
        }

        public override string ToString()
        {
            return this.FullName;
        }
    }
}