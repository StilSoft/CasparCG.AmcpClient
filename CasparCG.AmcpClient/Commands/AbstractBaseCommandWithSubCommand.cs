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
    public abstract class AbstractBaseCommandWithSubCommand : AbstractBaseCommandWithSubCommand<AmcpResponse>
    {

    }

    [CommandBuilderObject]
    public abstract class AbstractBaseCommandWithSubCommand<TResponse> : AbstractBaseCommand<TResponse>
        where TResponse : AmcpResponse, new()
    {
        [Required]
        [CommandParameter(1)]
        internal abstract string SubCommandName { get; }
    }
}