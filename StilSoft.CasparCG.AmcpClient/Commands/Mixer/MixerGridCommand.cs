//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using StilSoft.CasparCG.AmcpClient.CommandBuilder.Attributes;
using StilSoft.CasparCG.AmcpClient.Commands.Mixer.Common;
using System.ComponentModel.DataAnnotations;

namespace StilSoft.CasparCG.AmcpClient.Commands.Mixer
{
    /// <summary>
    /// Create a grid of video layers.
    /// </summary>
    public class MixerGridCommand : AbstractMixerChannelCommandWithSubCommand
    {
        // MIXER
        // [video_channel:int]
        // GRID 
        // [resolution:int] 
        // {
        //     [duration:int] 
        //     {
        //         [tween:string]
        //         |linear
        //     }
        //     |0 linear 
        // } 

        internal override string SubCommandName { get; } = "GRID";

        [Required]
        [Range(0, int.MaxValue)]
        [CommandParameter]
        public int? Resolution { get; set; }

        [CommandParameter]
        public Transform Transform { get; set; }


        public MixerGridCommand(int? channel = null, int? resolution = null, Transform transform = null)
        {
            Channel = channel;
            Resolution = resolution;
            Transform = transform;
        }
    }
}