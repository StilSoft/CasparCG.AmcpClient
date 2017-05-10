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
    /// Set the blend mode for a layer.
    /// </summary>
    public class MixerBlendSetCommand : AbstractMixerLayerCommand
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

        internal override string MixerCommandName { get; } = "BLEND";

        [Required]
        [EnumDataType(typeof(BlendMode))]
        [EnumToString]
        [CommandParameter]
        public BlendMode? BlendMode { get; set; }


        public MixerBlendSetCommand(int? channel = null, int? layer = null, BlendMode? blendMode = null)
        {
            Channel = channel;
            Layer = layer;
            BlendMode = blendMode;
        }
    }
}