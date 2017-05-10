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
    /// Change the volume of a layer.
    /// </summary>
    public class MixerVolumeSetCommand : AbstractMixerLayerCommand
    {
        // MIXER
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // } 
        // VOLUME 
        // {
        //     [volume:float] 
        //     {
        //         [duration:int] 
        //         {
        //             [tween:string]
        //             |linear
        //         }
        //         |0 linear 
        //     } 
        // }

        internal override string MixerCommandName { get; } = "VOLUME";

        [Required]
        [Range(0.0, 10.0)]
        [NumberToStringCulture("en-US")]
        [CommandParameter]
        public double? Volume { get; set; }

        [CommandParameter]
        public Transform Transform { get; set; }


        public MixerVolumeSetCommand(int? channel = null, int? layer = null, double? volume = null, Transform transform = null)
        {
            Channel = channel;
            Layer = layer;
            Volume = volume;
            Transform = transform;
        }
    }
}