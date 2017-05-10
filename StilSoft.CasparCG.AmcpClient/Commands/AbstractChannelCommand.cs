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

namespace StilSoft.CasparCG.AmcpClient.Commands
{
    // Default response for all Channel commands.
    public abstract class AbstractChannelCommand : AbstractChannelCommand<AmcpResponse>
    {

    }

    public abstract class AbstractChannelCommand<TResponse> : AbstractBaseCommand<TResponse>
        where TResponse : AmcpResponse, new()
    {
        /// <summary>
        /// Video channel.
        /// </summary>
        [Required]
        [Range(1, 9999)]
        [CommandParameter(1)]
        public int? Channel { get; set; }
    }
}