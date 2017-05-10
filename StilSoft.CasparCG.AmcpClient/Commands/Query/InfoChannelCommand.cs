//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using StilSoft.CasparCG.AmcpClient.Commands.Query.Common.Response;

namespace StilSoft.CasparCG.AmcpClient.Commands.Query
{
    /// <summary>
    /// Get information about a channel.
    /// </summary>
    public class InfoChannelCommand : AbstractChannelCommand<InfoChannelCommandResponse>
    {
        // INFO
        // [video_channel:int]
        // {
        //     -[layer:int]
        // }

        internal override string CommandName { get; } = "INFO";


        public InfoChannelCommand(int? channel = null)
        {
            Channel = channel;
        }
    }
}