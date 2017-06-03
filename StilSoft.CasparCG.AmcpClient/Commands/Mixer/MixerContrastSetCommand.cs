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
using StilSoft.CasparCG.AmcpClient.CommandBuilder.Attributes.Converters;
using StilSoft.CasparCG.AmcpClient.Commands.Mixer.Common;
using System.ComponentModel.DataAnnotations;

namespace StilSoft.CasparCG.AmcpClient.Commands.Mixer
{
    /// <summary>
    /// Change the contrast of a layer.
    /// </summary>
    public class MixerContrastSetCommand : AbstractMixerLayerCommandWithSubCommand
    {
        // MIXER
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // } 
        // CONTRAST 
        // {
        //     [contrast:float] 
        //     {
        //         [duration:int] 
        //         {
        //             [tween:string]
        //             |linear
        //         }
        //         |0 linear 
        //     } 
        // }

        internal override string SubCommandName { get; } = "CONTRAST";

        [Required]
        [Range(0.0, 1.0)]
        [NumberToStringCulture("en-US")]
        [CommandParameter]
        public double? Contrast { get; set; }

        [CommandParameter]
        public Transform Transform { get; set; }


        public MixerContrastSetCommand(int? channel = null, int? layer = null, double? contrast = null, Transform transform = null)
        {
            Channel = channel;
            Layer = layer;
            Contrast = contrast;
            Transform = transform;
        }
    }
}