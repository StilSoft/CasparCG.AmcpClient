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
using System.ComponentModel.DataAnnotations;

namespace StilSoft.CasparCG.AmcpClient.Commands.Mixer
{
    /// <summary>
    /// Enable or disable mipmapping for a layer.
    /// </summary>
    public class MixerMipmapSetCommand : AbstractMixerLayerCommand
    {
        // MIXER 
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // } 
        // MIPMAP 
        // {
        //     [mipmap:0,1]
        //     |0
        // }

        internal override string MixerCommandName { get; } = "MIPMAP";

        [Required]
        [BooleanToString("1", "0")]
        [CommandParameter]
        public bool? EnableMipmap { get; set; }


        public MixerMipmapSetCommand(int? channel = null, int? layer = null, bool? enableMipmap = null)
        {
            Channel = channel;
            Layer = layer;
            EnableMipmap = enableMipmap;
        }
    }
}