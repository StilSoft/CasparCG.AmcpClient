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
using StilSoft.CasparCG.AmcpClient.CommandBuilder.Attributes.Validations;
using StilSoft.CasparCG.AmcpClient.Commands.Thumbnail.Common.Response;
using System.ComponentModel.DataAnnotations;

namespace StilSoft.CasparCG.AmcpClient.Commands.Thumbnail
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