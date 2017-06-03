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
    /// Change the clipping viewport of a layer.
    /// </summary>
    public class MixerClipSetCommand : AbstractMixerLayerCommandWithSubCommand
    {
        // MIXER
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // } 
        // CLIP 
        // {
        //     [x:float]
        //     [y:float]
        //     [width:float]
        //     [height:float]
        //     {
        //         [duration:int]
        //         {
        //             [tween:string]
        //             |linear
        //         }
        //         |0 linear
        //     } 
        // }

        internal override string SubCommandName { get; } = "CLIP";

        [Required]
        [CommandParameter]
        public MixerClip Clip { get; set; }

        [CommandParameter]
        public Transform Transform { get; set; }


        public MixerClipSetCommand(int? channel = null, int? layer = null, MixerClip clip = null, Transform transform = null)
        {
            Channel = channel;
            Layer = layer;
            Clip = clip;
            Transform = transform;
        }
    }
}