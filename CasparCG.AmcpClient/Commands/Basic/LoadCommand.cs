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
    /// Load a media file or resource to the foreground.
    /// </summary>
    public class LoadCommand : AbstractLayerCommand
    {
        // LOAD
        // [channel:int]
        // {
        //     -[layer:int]
        // }
        // [clip:string]
        // {
        //     [loop:LOOP]
        // }
        // {
        //     SEEK [frame:int]
        // } 
        // {
        //     LENGTH [frames:int]
        // } 
        // {
        //     FILTER filter:string]
        // }

        internal override string CommandName { get; } = "LOAD";

        [Required]
        [IsValidFullName]
        [WindowsToUnixPath]
        [ValueToEscapedString]
        [CommandParameter("\"{0}\"")]
        public string MediaFullName { get; set; }

        [BooleanToString("LOOP", "")]
        [CommandParameter]
        public bool? Loop { get; set; }

        [Range(1, int.MaxValue)]
        [CommandParameter("SEEK {0}")]
        public int? Seek { get; set; }

        [Range(1, int.MaxValue)]
        [CommandParameter("LENGTH {0}")]
        public int? Length { get; set; }

        [CommandParameter("FILTER {0}")]
        public string Filter { get; set; }


        public LoadCommand(int? channel = null, int? layer = null, string mediaFullName = "", bool? loop = null,
                           int? seek = null, int? length = null, string filter = null)
        {
            Channel = channel;
            Layer = layer;
            MediaFullName = mediaFullName;
            Loop = loop;
            Seek = seek;
            Length = length;
            Filter = filter;
        }
    }
}