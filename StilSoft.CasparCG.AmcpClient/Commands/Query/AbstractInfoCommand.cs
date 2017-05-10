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

namespace StilSoft.CasparCG.AmcpClient.Commands.Query
{
    /// <summary>
    /// Abstract class used in some of the Info Commands with default response <see cref="AmcpResponse"/>.
    /// </summary>
    public abstract class AbstractInfoCommand : AbstractInfoCommand<AmcpResponse>
    {

    }

    /// <summary>
    /// Abstract class used in some of the Info Commands
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class AbstractInfoCommand<TResponse> : AbstractBaseCommand<TResponse>
        where TResponse : AmcpResponse, new()
    {
        internal override string CommandName { get; } = "INFO";

        [Required]
        [CommandParameter(1)]
        internal abstract string InfoCommandName { get; }
    }
}