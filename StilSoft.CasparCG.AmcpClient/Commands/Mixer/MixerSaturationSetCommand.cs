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
    /// Change the saturation of a layer.
    /// </summary>
    public class MixerSaturationSetCommand : AbstractMixerLayerCommandWithSubCommand
    {
        // MIXER
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // } 
        // SATURATION 
        // {
        //     [saturation:float] 
        //     {
        //         [duration:int] 
        //         {
        //             [tween:string]
        //             |linear
        //         }
        //         |0 linear 
        //     } 
        // }

        internal override string SubCommandName { get; } = "SATURATION";

        [Required]
        [Range(0.0, 1.0)]
        [NumberToStringCulture("en-US")]
        [CommandParameter]
        public double? Saturation { get; set; }

        [CommandParameter]
        public Transform Transform { get; set; }


        public MixerSaturationSetCommand(int? channel = null, int? layer = null, double? saturation = null, Transform transform = null)
        {
            Channel = channel;
            Layer = layer;
            Saturation = saturation;
            Transform = transform;
        }
    }
}