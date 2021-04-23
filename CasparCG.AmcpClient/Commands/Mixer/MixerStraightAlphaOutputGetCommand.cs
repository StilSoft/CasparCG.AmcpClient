//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using CasparCg.AmcpClient.Commands.Mixer.Common.Response;

namespace CasparCg.AmcpClient.Commands.Mixer
{
    /// <summary>
    /// Get straight alpha output on or off for a channel.
    /// </summary>
    public class MixerStraightAlphaOutputGetCommand : AbstractMixerChannelCommandWithSubCommand<MixerStraightAlphaOutputGetCommandResponse>
    {
        // MIXER
        // [video_channel:int]
        // STRAIGHT_ALPHA_OUTPUT 

        internal override string SubCommandName { get; } = "STRAIGHT_ALPHA_OUTPUT";


        public MixerStraightAlphaOutputGetCommand(int? channel = null)
        {
            Channel = channel;
        }
    }
}