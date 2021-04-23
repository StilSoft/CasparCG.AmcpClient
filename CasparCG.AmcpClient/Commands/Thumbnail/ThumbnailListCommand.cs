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
using CasparCg.AmcpClient.CommandBuilder.Attributes.Converters;
using CasparCg.AmcpClient.CommandBuilder.Attributes.Validations;
using CasparCg.AmcpClient.Commands.Thumbnail.Common.Response;

namespace CasparCg.AmcpClient.Commands.Thumbnail
{
    /// <summary>
    /// List thumbnails.
    /// </summary>
    public class ThumbnailListCommand : AbstractThumbnailCommandWithSubCommand<ThumbnailListCommandResponse>
    {
        // THUMBNAIL 
        // LIST 
        // {
        //     [sub_directory:string]
        // }

        internal override string SubCommandName { get; } = "LIST";

        [IsValidPath]
        [WindowsToUnixPath]
        [ValueToEscapedString]
        [CommandParameter("\"{0}\"")]
        public string SubDirectory { get; set; }


        public ThumbnailListCommand(string subDirectory = "")
        {
            SubDirectory = subDirectory;
        }
    }
}