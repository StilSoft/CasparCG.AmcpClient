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

namespace CasparCg.AmcpClient.Commands.Query.Common.Info
{
    public class ThreadInfo
    {
        public long Id { get; }
        public string Name { get; }

        public ThreadInfo(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public static ThreadInfo Parse(string data)
        {
            // 2076 AMCPCommandQueue Channel 1 for Console
            // 2128 oal_consumer
            // 2132 video_channel 2

            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentNullException(nameof(data));

            try
            {
                var threadIdEndIndex = data.IndexOf(' ');
                var theadId = long.Parse(data.Substring(0, threadIdEndIndex));
                var threadName = data.Substring(threadIdEndIndex + 1);

                if (string.IsNullOrWhiteSpace(threadName))
                    throw new FormatException("Invalid Thread Name.");

                return new ThreadInfo(theadId, threadName);
            }
            catch (Exception ex)
            {
                throw new FormatException("Input string was not in a correct format.", ex);
            }
        }
    }
}
