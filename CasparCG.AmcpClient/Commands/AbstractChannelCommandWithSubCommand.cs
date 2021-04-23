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
using CasparCg.AmcpClient.Common;

namespace CasparCg.AmcpClient.Commands
{
    public abstract class AbstractChannelCommandWithSubCommand : AbstractChannelCommandWithSubCommand<AmcpResponse>
    {
        
    }

    public abstract class AbstractChannelCommandWithSubCommand<TResponse> : AbstractChannelCommand<TResponse>
        where TResponse : AmcpResponse, new()
    {
        [Required]
        [CommandParameter(2)]
        internal abstract string SubCommandName { get; }
    }
}