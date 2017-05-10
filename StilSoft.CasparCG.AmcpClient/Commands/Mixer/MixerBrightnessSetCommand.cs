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
    /// Change the brightness of a layer.
    /// </summary>
    public class MixerBrightnessSetCommand : AbstractMixerLayerCommand
    {
        // MIXER
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // } 
        // BRIGHTNESS 
        // {
        //     [brightness:float] 
        //     {
        //         [duration:int] 
        //         {
        //             [tween:string]
        //             |linear
        //         }
        //         |0 linear 
        //     } 
        // }

        internal override string MixerCommandName { get; } = "BRIGHTNESS";

        [Required]
        [Range(0.0, 1.0)]
        [NumberToStringCulture("en-US")]
        [CommandParameter]
        public double? Brightness { get; set; }

        [CommandParameter]
        public Transform Transform { get; set; }


        public MixerBrightnessSetCommand(int? channel = null, int? layer = null, double? brightness = null, Transform transform = null)
        {
            Channel = channel;
            Layer = layer;
            Brightness = brightness;
            Transform = transform;
        }
    }
}