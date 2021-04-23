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

namespace CasparCg.AmcpClient.Commands.Basic
{
    /// <summary>
    /// Load a web page to the foreground.
    /// </summary>
    public class LoadHtmlCommand : AbstractLayerCommandWithSubCommand
    {
        // LOAD
        // [channel:int]
        // {
        //     -[layer:int]
        // }
        // [HTML]
        // [url:string]
        // {
        //     FILTER filter:string]
        // }

        internal override string CommandName { get; } = "LOAD";

        internal override string SubCommandName { get; } = "[HTML]";

        [Required]
        [IsValidUrl]
        [ValueToEscapedString]
        [CommandParameter("\"{0}\"")]
        public string Url { get; set; }

        [CommandParameter("FILTER {0}")]
        public string Filter { get; set; }


        public LoadHtmlCommand(int? channel = null, int? layer = null, string url = "", string filter = null)
        {
            Channel = channel;
            Layer = layer;
            Url = url;
            Filter = filter;
        }
    }
}