//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using System.ComponentModel.DataAnnotations;
using CasparCg.AmcpClient.CommandBuilder.Attributes;
using CasparCg.AmcpClient.CommandBuilder.Attributes.Converters;

namespace CasparCg.AmcpClient.Commands.Mixer
{
    /// <summary>
    /// Turn straight alpha output on or off for a channel.
    /// </summary>
    public class MixerStraightAlphaOutputSetCommand : AbstractMixerChannelCommandWithSubCommand
    {
        // MIXER
        // [video_channel:int]
        // STRAIGHT_ALPHA_OUTPUT 
        // {
        //     [straight_alpha:0,1|0]
        // }

        internal override string SubCommandName { get; } = "STRAIGHT_ALPHA_OUTPUT";

        [Required]
        [BooleanToString("1", "0")]
        [CommandParameter]
        public bool? EnableStraightAlpha { get; set; }


        public MixerStraightAlphaOutputSetCommand(int? channel = null, bool? enableStraightAlpha = null)
        {
            Channel = channel;
            EnableStraightAlpha = enableStraightAlpha;
        }
    }
}