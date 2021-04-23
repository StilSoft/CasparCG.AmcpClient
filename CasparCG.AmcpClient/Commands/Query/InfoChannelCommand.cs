//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using CasparCg.AmcpClient.Commands.Query.Common.Response;

namespace CasparCg.AmcpClient.Commands.Query
{
    /// <summary>
    /// Get information about a channel.
    /// </summary>
    public class InfoChannelCommand : AbstractInfoChannelCommand<InfoChannelCommandResponse>
    {
        // INFO
        // [video_channel:int]

        public InfoChannelCommand(int? channel = null)
        {
            Channel = channel;
        }
    }
}