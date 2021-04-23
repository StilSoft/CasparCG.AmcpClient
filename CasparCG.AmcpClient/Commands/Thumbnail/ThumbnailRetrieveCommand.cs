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
using CasparCg.AmcpClient.Commands.Thumbnail.Common.Response;

namespace CasparCg.AmcpClient.Commands.Thumbnail
{
    /// <summary>
    /// Retrieve a thumbnail.
    /// </summary>
    public class ThumbnailRetrieveCommand : AbstractThumbnailCommandWithSubCommand<ThumbnailRetrieveCommandResponse>
    {
        // THUMBNAIL 
        // RETRIEVE
        // [filename:string]

        internal override string SubCommandName { get; } = "RETRIEVE";

        [Required]
        [IsValidFullName]
        [WindowsToUnixPath]
        [ValueToEscapedString]
        [CommandParameter("\"{0}\"")]
        public string ThumbnailFullName { get; set; }


        public ThumbnailRetrieveCommand(string thumbnailFullName = "")
        {
            ThumbnailFullName = thumbnailFullName;
        }
    }
}