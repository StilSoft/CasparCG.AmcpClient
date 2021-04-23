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

namespace CasparCg.AmcpClient.Commands.Thumbnail
{
    /// <summary>
    /// Regenerate a thumbnail.
    /// </summary>
    public class ThumbnailGenerateCommand : AbstractThumbnailCommandWithSubCommand
    {
        // THUMBNAIL 
        // GENERATE
        // [filename:string]

        internal override string SubCommandName { get; } = "GENERATE";

        [Required]
        [IsValidFullName]
        [WindowsToUnixPath]
        [ValueToEscapedString]
        [CommandParameter("\"{0}\"")]
        public string ThumbnailFullName { get; set; }


        public ThumbnailGenerateCommand(string thumbnailFullName = "")
        {
            ThumbnailFullName = thumbnailFullName;
        }
    }
}