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
    /// Adjust the video levels of a layer.
    /// </summary>
    public class MixerLevelsSetCommand : AbstractMixerLayerCommand
    {
        // MIXER
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // } 
        // LEVELS 
        // {
        //     [min-input:float] 
        //     [max-input:float]
        //     [gamma:float]
        //     [min-output:float]
        //     [max-output:float]
        //     {
        //         [duration:int]
        //         {
        //             [tween:string]
        //             |linear
        //         }
        //         |0 linear
        //     } 
        // }

        internal override string MixerCommandName { get; } = "LEVELS";

        [Required]
        [CommandParameter]
        public MixerLevels Levels { get; set; }

        [CommandParameter]
        public Transform Transform { get; set; }


        public MixerLevelsSetCommand(int? channel = null, int? layer = null, MixerLevels levels = null, Transform transform = null)
        {
            Channel = channel;
            Layer = layer;
            Levels = levels;
            Transform = transform;
        }
    }
}