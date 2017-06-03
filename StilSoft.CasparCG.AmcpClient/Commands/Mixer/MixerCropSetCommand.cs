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
    /// Crop a layer.
    /// </summary>
    public class MixerCropSetCommand : AbstractMixerLayerCommandWithSubCommand
    {
        // MIXER
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // } 
        // CROP 
        // {
        //     [left-edge:float]
        //     [top-edge:float]
        //     [right-edge:float]
        //     [bottom-edge:float]
        //     {
        //         [duration:int]
        //         {
        //             [tween:string]
        //             |linear
        //         }
        //         |0 linear
        //     } 
        // }

        internal override string SubCommandName { get; } = "CROP";

        [Required]
        [CommandParameter]
        public MixerCrop Crop { get; set; }

        [CommandParameter]
        public Transform Transform { get; set; }


        public MixerCropSetCommand(int? channel = null, int? layer = null, MixerCrop crop = null, Transform transform = null)
        {
            Channel = channel;
            Layer = layer;
            Crop = crop;
            Transform = transform;
        }
    }
}