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
using CasparCg.AmcpClient.Commands.Mixer.Common;

namespace CasparCg.AmcpClient.Commands.Mixer
{
    /// <summary>
    /// Set the blend mode for a layer.
    /// </summary>
    public class MixerBlendSetCommand : AbstractMixerLayerCommandWithSubCommand
    {
        // MIXER
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // } 
        // BLEND 
        // {
        //     [blend:string]
        //     |normal
        // }

        internal override string SubCommandName { get; } = "BLEND";

        [Required]
        [EnumDataType(typeof(BlendMode))]
        [EnumToString]
        [CommandParameter]
        public BlendMode? BlendMode { get; set; }

        [CommandParameter]
        public Transform Transform { get; set; }


        public MixerBlendSetCommand(int? channel = null, int? layer = null, BlendMode? blendMode = null, Transform transform = null)
        {
            Channel = channel;
            Layer = layer;
            BlendMode = blendMode;
            Transform = transform;
        }
    }
}