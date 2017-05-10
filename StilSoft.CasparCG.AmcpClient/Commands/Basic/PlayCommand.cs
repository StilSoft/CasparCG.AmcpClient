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
using StilSoft.CasparCG.AmcpClient.CommandBuilder.Attributes.Conditions;
using StilSoft.CasparCG.AmcpClient.CommandBuilder.Attributes.Converters;
using StilSoft.CasparCG.AmcpClient.CommandBuilder.Attributes.Validations;
using StilSoft.CasparCG.AmcpClient.Commands.Basic.Common;

namespace StilSoft.CasparCG.AmcpClient.Commands.Basic
{
    /// <summary>
    /// Play a media file or resource.
    /// </summary>
    public class PlayCommand : AbstractLayerCommand
    {
        // PLAY
        // [channel:int]
        // {
        //     -[layer:int]
        // }
        // {
        //     [clip:string]
        // }
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

        internal override string CommandName { get; } = "PLAY";

        [IsValidFullName]
        [WindowsToUnixPath]
        [ValueToEscapedString]
        [CommandParameter("\"{0}\"")]
        public string MediaFullName { get; set; }

        [IncludeIfIncluded(nameof(MediaFullName))]
        [BooleanToString("LOOP", "")]
        [CommandParameter]
        public bool? Loop { get; set; }

        [IncludeIfIncluded(nameof(MediaFullName))]
        [CommandParameter]
        public Transition Transition { get; set; }

        [IncludeIfIncluded(nameof(MediaFullName))]
        [CommandParameter("SEEK {0}")]
        public int? Seek { get; set; }

        [IncludeIfIncluded(nameof(MediaFullName))]
        [CommandParameter("LENGTH {0}")]
        public int? Length { get; set; }

        [IncludeIfIncluded(nameof(MediaFullName))]
        [CommandParameter("FILTER {0}")]
        public string Filter { get; set; }


        public PlayCommand(int? channel = null, int? layer = null, string mediaFullName = "", bool? loop = null,
                           int? seek = null, int? length = null, Transition transition = null, string filter = null)
        {
            Channel = channel;
            Layer = layer;
            MediaFullName = mediaFullName;
            Loop = loop;
            Seek = seek;
            Length = length;
            Transition = transition;
            Filter = filter;
        }
    }
}