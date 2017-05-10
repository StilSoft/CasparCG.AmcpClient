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

namespace StilSoft.CasparCG.AmcpClient.Commands.Mixer
{
    /// <summary>
    /// Let a layer act as alpha for the one above.
    /// </summary>
    public class MixerKeyerSetCommand : AbstractMixerLayerCommand
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

        internal override string MixerCommandName { get; } = "KEYER";

        [Required]
        [BooleanToString("1", "0")]
        [CommandParameter]
        public bool? EnableKeyer { get; set; }


        public MixerKeyerSetCommand(int? channel = null, int? layer = null, bool? enableKeyer = null)
        {
            Channel = channel;
            Layer = layer;
            EnableKeyer = enableKeyer;
        }
    }
}