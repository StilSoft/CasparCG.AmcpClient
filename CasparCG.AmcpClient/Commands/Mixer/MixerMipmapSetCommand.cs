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
    /// Enable or disable mipmapping for a layer.
    /// </summary>
    public class MixerMipmapSetCommand : AbstractMixerLayerCommandWithSubCommand
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

        internal override string SubCommandName { get; } = "MIPMAP";

        [Required]
        [BooleanToString("1", "0")]
        [CommandParameter]
        public bool? EnableMipmap { get; set; }

        [CommandParameter]
        public Transform Transform { get; set; }


        public MixerMipmapSetCommand(int? channel = null, int? layer = null, bool? enableMipmap = null, Transform transform = null)
        {
            Channel = channel;
            Layer = layer;
            EnableMipmap = enableMipmap;
            Transform = transform;
        }
    }
}