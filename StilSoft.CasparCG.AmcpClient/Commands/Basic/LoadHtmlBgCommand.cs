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
using StilSoft.CasparCG.AmcpClient.CommandBuilder.Attributes.Converters;
using StilSoft.CasparCG.AmcpClient.Commands.Basic.Common;
using System.ComponentModel.DataAnnotations;
using StilSoft.CasparCG.AmcpClient.CommandBuilder.Attributes.Validations;

namespace StilSoft.CasparCG.AmcpClient.Commands.Basic
{
    /// <summary>
    /// Load a web page in the background.
    /// </summary>
    public class LoadHtmlBgCommand : AbstractLayerCommand
    {
        // LOADBG
        // [channel:int]
        // {
        //     -[layer:int]
        // }
        // [HTML]
        // [url:string]
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
        // {
        //     [auto:AUTO]
        // }

        internal override string CommandName { get; } = "LOADBG";

        [CommandParameter(3)]
        internal string SubCommand { get; } = "[HTML]";

        [Required]
        [IsValidUrl]
        [ValueToEscapedString]
        [CommandParameter("\"{0}\"")]
        public string Url { get; set; }

        [CommandParameter]
        public Transition Transition { get; set; }

        [CommandParameter("FILTER {0}")]
        public string Filter { get; set; }

        [BooleanToString("AUTO", "")]
        [CommandParameter]
        public bool? AutoStart { get; set; }


        public LoadHtmlBgCommand(int? channel = null, int? layer = null, string url = "", bool? autoStart = null, Transition transition = null, string filter = null)
        {
            Channel = channel;
            Layer = layer;
            Url = url;
            Transition = transition;
            Filter = filter;
            AutoStart = autoStart;
        }
    }
}