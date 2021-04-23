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
using CasparCg.AmcpClient.CommandBuilder.Attributes.Conditions;
using CasparCg.AmcpClient.CommandBuilder.Attributes.Converters;
using CasparCg.AmcpClient.CommandBuilder.Attributes.Validations;
using CasparCg.AmcpClient.Commands.Mixer.Common;

namespace CasparCg.AmcpClient.Commands.Mixer
{
    /// <summary>
    /// Enable chroma keying on a layer.
    /// </summary>
    public class MixerChromaSetCommand : AbstractMixerLayerCommandWithSubCommand
    {
        // MIXER 
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // }
        // CHROMA 
        // {
        //     [enable:0,1] 
        //     {
        //         [target_hue:float] 
        //         [hue_width:float] 
        //         [min_saturation:float]
        //         [min_brightness:float]
        //         [softness:float]
        //         [spill_suppress:float]
        //         [spill_suppress_saturation:float]
        //         [show_mask:0,1]
        //     }
        // }
        // {
        //     [duration:int]
        //     {
        //         [tween:string]
        //         |linear
        //     }
        //     |0 linear
        // }

        internal override string SubCommandName { get; } = "CHROMA";

        /// <summary>
        /// Enable or Disable chroma keying on a layer.
        /// </summary>
        [Required]
        [BooleanToString("1", "0")]
        [CommandParameter]
        public bool? EnableChroma { get; set; }

        /// <summary>
        /// Chroma key.
        /// This property is required if <see cref="EnableChroma"/> is <c>true</c>.
        /// </summary>
        [RequiredIfEqual(nameof(EnableChroma), true)]
        [IncludeIfEqual(nameof(EnableChroma), true)]
        [CommandParameter]
        public MixerChroma Chroma { get; set; }

        /// <summary>
        /// Chroma keyer transformation.
        /// </summary>
        [IncludeIfEqual(nameof(EnableChroma), true)] 
        [CommandParameter]
        public Transform Transform { get; set; }


        /// <param name="channel"><see cref="AbstractChannelCommand.Channel"/></param>
        /// <param name="layer"><see cref="AbstractLayerCommand.Layer"/></param>
        /// <param name="enableChroma"><see cref="EnableChroma"/></param>
        /// <param name="chroma"><see cref="Chroma"/></param>
        /// <param name="transform"><see cref="Transform"/></param>
        public MixerChromaSetCommand(int? channel = null, int? layer = null, bool? enableChroma = null, MixerChroma chroma = null, Transform transform = null)
        {
            Channel = channel;
            Layer = layer;
            EnableChroma = enableChroma;
            Chroma = chroma;
            Transform = transform;
        }
    }
}