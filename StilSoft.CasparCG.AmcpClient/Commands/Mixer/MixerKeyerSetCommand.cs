﻿//////////////////////////////////////////////////////////////////////////////////
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
using StilSoft.CasparCG.AmcpClient.Commands.Mixer.Common;

namespace StilSoft.CasparCG.AmcpClient.Commands.Mixer
{
    /// <summary>
    /// Let a layer act as alpha for the one above.
    /// </summary>
    public class MixerKeyerSetCommand : AbstractMixerLayerCommandWithSubCommand
    {
        // MIXER
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // }
        // KEYER
        // {
        //     keyer:0,1
        //     |0
        // }

        internal override string SubCommandName { get; } = "KEYER";

        [Required]
        [BooleanToString("1", "0")]
        [CommandParameter]
        public bool? EnableKeyer { get; set; }

        [CommandParameter]
        public Transform Transform { get; set; }


        public MixerKeyerSetCommand(int? channel = null, int? layer = null, bool? enableKeyer = null, Transform transform = null)
        {
            Channel = channel;
            Layer = layer;
            EnableKeyer = enableKeyer;
            Transform = transform;
        }
    }
}