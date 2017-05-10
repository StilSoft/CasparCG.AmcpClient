//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using StilSoft.CasparCG.AmcpClient.Commands.Mixer.Common.Response;

namespace StilSoft.CasparCG.AmcpClient.Commands.Mixer
{
    /// <summary>
    /// Get straight alpha output on or off for a channel.
    /// </summary>
    public class MixerStraightAlphaOutputGetCommand : AbstractMixerChannelCommand<MixerStraightAlphaOutputGetCommandResponse>
    {
        // MIXER
        // [video_channel:int]
        // STRAIGHT_ALPHA_OUTPUT 

        internal override string MixerCommandName { get; } = "STRAIGHT_ALPHA_OUTPUT";


        public MixerStraightAlphaOutputGetCommand(int? channel = null)
        {
            Channel = channel;
        }
    }
}