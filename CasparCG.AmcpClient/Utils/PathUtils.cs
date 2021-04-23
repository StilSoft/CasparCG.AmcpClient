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

namespace CasparCg.AmcpClient.Utils
{
    public static class PathUtils
    {
        public const char WindowsDirectorySeparator = '\\';
        public const char UnixDirectorySeparator = '/';


        public static string UnixToWindowsPath(string path)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            return path.Replace(UnixDirectorySeparator, WindowsDirectorySeparator);
        }

        public static string WindowsToUnixPath(string path)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            return path.Replace(WindowsDirectorySeparator, UnixDirectorySeparator);
        }

        public static bool IsValidFileName(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));

            return fileName.IndexOfAny(Path.GetInvalidFileNameChars()) == -1;
        }

        public static bool IsValidPath(string path)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            return path.IndexOfAny(Path.GetInvalidPathChars()) == -1;
        }
    }
}