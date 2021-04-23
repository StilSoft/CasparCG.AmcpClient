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

namespace CasparCg.AmcpClient.Commands.Basic
{
    /// <summary>
    /// Swap layers between channels.
    /// </summary>
    public class SwapCommand : AbstractBaseCommand
    {
        // SWAP
        // [channel1:int]
        // {
        //     -[layer1:int]
        // }
        // [channel2:int]
        // {
        //     -[layer2:int]
        // }
        // {
        //     [transforms:TRANSFORMS]
        // }

        internal override string CommandName { get; } = "SWAP";

        [Required]
        [Range(1, 9999)]
        [CommandParameter]
        public int? ChannelA { get; set; }

        [Range(0, 9999)]
        [IncludeIfIncluded(nameof(LayerB))]
        [CommandParameter("-{0}", true)]
        public int? LayerA { get; set; }

        [Required]
        [Range(1, 9999)]
        [CommandParameter]
        public int? ChannelB { get; set; }

        [Range(0, 9999)]
        [IncludeIfIncluded(nameof(LayerA))]
        [CommandParameter("-{0}", true)]
        public int? LayerB { get; set; }

        [BooleanToString("TRANSFORMS", "")]
        [CommandParameter]
        public bool? Transforms { get; set; }


        public SwapCommand(int? channelA = null, int? channelB = null, bool? transforms = null) : this(channelA, null, channelB, null, transforms)
        {
            
        }

        public SwapCommand(int? channelA = null, int? layerA = null,  int? channelB = null, int? layerB = null, bool? transforms = null)
        {
            ChannelA = channelA;
            ChannelB = channelB;
            LayerA = layerA;
            LayerB = layerB;
            Transforms = transforms;
        }
    }
}