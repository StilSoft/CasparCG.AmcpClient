//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////



namespace StilSoft.CasparCG.AmcpClient.Commands.Thumbnail
{
    /// <summary>
    /// Regenerate all thumbnails.
    /// </summary>
    public class ThumbnailGenerateAllCommand : AbstractThumbnailCommand
    {
        // THUMBNAIL 
        // GENERATE_ALL

        internal override string ThumbnailCommandName { get; } = "GENERATE_ALL";
    }
}