//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using CasparCg.AmcpClient.CommandBuilder.Attributes;
using CasparCg.AmcpClient.CommandBuilder.Attributes.Conditions;
using CasparCg.AmcpClient.CommandBuilder.Attributes.Converters;
using CasparCg.AmcpClient.CommandBuilder.Attributes.Validations;
using CasparCg.AmcpClient.Commands.Basic.Common;

namespace CasparCg.AmcpClient.Commands.Basic
{
    /// <summary>
    /// Play a web page.
    /// </summary>
    public class PlayHtmlCommand : AbstractLayerCommandWithSubCommand
    {
        // PLAY
        // [channel:int]
        // {
        //     -[layer:int]
        // }
        // { 
        //     [HTML] 
        // }
        // {
        //     [url:string]
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
        //     FILTER [filter:string]
        // }

        internal override string CommandName { get; } = "PLAY";

        [IncludeIfIncluded(nameof(Url))]
        internal override string SubCommandName { get; } = "[HTML]";

        [IsValidUrl]
        [ValueToEscapedString]
        [CommandParameter("\"{0}\"")]
        public string Url { get; set; }

        [IncludeIfIncluded(nameof(Url))]
        [CommandParameter]
        public Transition Transition { get; set; }
        
        [IncludeIfIncluded(nameof(Url))]
        [CommandParameter("FILTER {0}")]
        public string Filter { get; set; }


        public PlayHtmlCommand(int? channel = null, int? layer = null, string url = "", Transition transition = null, string filter = null)
        {
            Channel = channel;
            Layer = layer;
            Url = url;
            Transition = transition;
            Filter = filter;
        }
    }
}