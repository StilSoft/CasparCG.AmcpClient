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
using CasparCg.AmcpClient.Commands.Mixer.Common;

namespace CasparCg.AmcpClient.Commands.Mixer
{
    /// <summary>
    /// Adjust the perspective transform of a layer.
    /// </summary>
    public class MixerPerspectiveSetCommand : AbstractMixerLayerCommandWithSubCommand
    {
        // MIXER
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // } 
        // PERSPECTIVE 
        // {
        //     [top-left-x:float] 
        //     [top-left-y:float]
        //     [top-right-x:float]
        //     [top-right-y:float]
        //     [bottom-right-x:float]
        //     [bottom-right-y:float]
        //     [bottom-left-x:float]
        //     [bottom-left-y:float]
        //     {
        //         [duration:int]
        //         {
        //             [tween:string]
        //             |linear
        //         }
        //         |0 linear
        //     } 
        // }

        internal override string SubCommandName { get; } = "PERSPECTIVE";

        [Required]
        [CommandParameter]
        public MixerPerspective Perspective { get; set; }

        [CommandParameter]
        public Transform Transform { get; set; }


        public MixerPerspectiveSetCommand(int? channel = null, int? layer = null, MixerPerspective perspective = null, Transform transform = null)
        {
            Channel = channel;
            Layer = layer;
            Perspective = perspective;
            Transform = transform;
        }
    }
}