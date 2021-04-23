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
    /// Get the current delay on a channel.
    /// </summary>
    public class InfoChannelDelayCommand : AbstractInfoChannelCommandWithSubCommand<InfoChannelDelayCommandResponse>
    {
        // INFO 
        // [video_channel:int]
        // DELAY

        internal override string SubCommandName { get; } = "DELAY";


        public InfoChannelDelayCommand(int? channel = null)
        {
            Channel = channel;
        }

        
    }
}