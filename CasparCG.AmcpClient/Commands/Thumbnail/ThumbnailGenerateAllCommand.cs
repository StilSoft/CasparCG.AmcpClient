//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////



namespace CasparCg.AmcpClient.Commands.Thumbnail
{
    /// <summary>
    /// Regenerate all thumbnails.
    /// </summary>
    public class ThumbnailGenerateAllCommand : AbstractThumbnailCommandWithSubCommand
    {
        // THUMBNAIL 
        // GENERATE_ALL

        internal override string SubCommandName { get; } = "GENERATE_ALL";
    }
}