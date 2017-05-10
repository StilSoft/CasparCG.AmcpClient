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

namespace StilSoft.CasparCG.AmcpClient.Commands.Thumbnail
{
    /// <summary>
    /// List thumbnails.
    /// </summary>
    public class ThumbnailListCommand : AbstractThumbnailCommand<ThumbnailListCommandResponse>
    {
        // THUMBNAIL 
        // LIST 
        // {
        //     [sub_directory:string]
        // }

        internal override string ThumbnailCommandName { get; } = "LIST";

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