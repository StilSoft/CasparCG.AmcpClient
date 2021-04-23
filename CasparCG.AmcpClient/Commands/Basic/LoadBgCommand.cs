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
using CasparCg.AmcpClient.CommandBuilder.Attributes.Validations;
using CasparCg.AmcpClient.Commands.Basic.Common;

namespace CasparCg.AmcpClient.Commands.Basic
{
    /// <summary>
    /// Load a media file or resource in the background.
    /// </summary>
    public class LoadBgCommand : AbstractLayerCommand
    {
        // LOADBG
        // [channel:int]
        // {
        //     -[layer:int]
        // }
        // [clip:string]
        // {
        //     [loop:LOOP]
        // }
        // {
        //     [transition:CUT,MIX,PUSH,WIPE,SLIDE] 
        //     [duration:int] 
        //     {
        //         [tween:string]
        //         |linear
        //     }
        //     {
        //         [direction:LEFT,RIGHT]
        //         |RIGHT
        //     }
        //     |CUT 0
        // }
        // {
        //     SEEK [frame:int]
        // } 
        // {
        //     LENGTH [frames:int]
        // } 
        // {
        //     FILTER [filter:string]
        // }
        // {
        //     [auto:AUTO]
        // }

        internal override string CommandName { get; } = "LOADBG";

        [Required]
        [IsValidFullName]
        [WindowsToUnixPath]
        [ValueToEscapedString]
        [CommandParameter("\"{0}\"")]
        public string MediaFullName { get; set; }

        [BooleanToString("LOOP", "")]
        [CommandParameter]
        public bool? Loop { get; set; }

        [CommandParameter]
        public Transition Transition { get; set; }

        [Range(1, int.MaxValue)]
        [CommandParameter("SEEK {0}")]
        public int? Seek { get; set; }

        [Range(1, int.MaxValue)]
        [CommandParameter("LENGTH {0}")]
        public int? Length { get; set; }

        // TODO if enter invalid value in filter caspar return successful but not play
        [CommandParameter("FILTER {0}")]
        public string Filter { get; set; }

        [BooleanToString("AUTO", "")]
        [CommandParameter]
        public bool? AutoStart { get; set; }


        public LoadBgCommand(int? channel = null, int? layer = null, string mediaFullName = "", bool? autoStart = null, bool? loop = null,
                             int? seek = null, int? length = null, Transition transition = null, string filter = null)
        {
            Channel = channel;
            Layer = layer;
            MediaFullName = mediaFullName;
            Loop = loop;
            Transition = transition;
            Seek = seek;
            Length = length;
            Filter = filter;
            AutoStart = autoStart;
        }
    }
}