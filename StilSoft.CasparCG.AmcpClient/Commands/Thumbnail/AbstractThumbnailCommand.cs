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
using StilSoft.CasparCG.AmcpClient.Common;
using System.ComponentModel.DataAnnotations;

namespace StilSoft.CasparCG.AmcpClient.Commands.Thumbnail
{
    public abstract class AbstractThumbnailCommand : AbstractThumbnailCommand<AmcpResponse>
    {

    }

    public abstract class AbstractThumbnailCommand<TResponse> : AbstractBaseCommand<TResponse>
        where TResponse : AmcpResponse, new()
    {
        internal override string CommandName { get; } = "THUMBNAIL";

        [Required]
        [CommandParameter(1)]
        internal abstract string ThumbnailCommandName { get; }
    }
}