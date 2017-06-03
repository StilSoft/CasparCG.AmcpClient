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
    /// Change the fill position and scale of a layer.
    /// </summary>
    public class MixerFillSetCommand : AbstractMixerLayerCommandWithSubCommand
    {
        // MIXER
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // } 
        // FILL 
        // {
        //     [x:float]
        //     [y:float]
        //     [x-scale:float]
        //     [y-scale:float]
        //     {
        //         [duration:int]
        //         {
        //             [tween:string]
        //             |linear
        //         }
        //         |0 linear
        //     } 
        // }

        internal override string SubCommandName { get; } = "FILL";

        [Required]
        [CommandParameter]
        public MixerFill Fill { get; set; }

        [CommandParameter]
        public Transform Transform { get; set; }


        public MixerFillSetCommand(int? channel = null, int? layer = null, MixerFill fill = null, Transform transform = null)
        {
            Channel = channel;
            Layer = layer;
            Fill = fill;
            Transform = transform;
        }
    }
}