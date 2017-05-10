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
    /// Rotate a layer.
    /// </summary>
    public class MixerRotationSetCommand : AbstractMixerLayerCommand
    {
        // MIXER
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // } 
        // ROTATION 
        // {
        //     [angle:float] 
        //     {
        //         [duration:int] 
        //         {
        //             [tween:string]
        //             |linear
        //         }
        //         |0 linear 
        //     } 
        // }

        internal override string MixerCommandName { get; } = "ROTATION";

        [Required]
        [NumberToStringCulture("en-US")]
        [CommandParameter]
        public double? Rotation { get; set; }

        [CommandParameter]
        public Transform Transform { get; set; }


        public MixerRotationSetCommand(int? channel = null, int? layer = null, double? rotation = null, Transform transform = null)
        {
            Channel = channel;
            Layer = layer;
            Rotation = rotation;
            Transform = transform;
        }
    }
}