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
using StilSoft.CasparCG.AmcpClient.CommandBuilder.Attributes.Conditions;
using StilSoft.CasparCG.AmcpClient.Common;
using System.ComponentModel.DataAnnotations;

namespace StilSoft.CasparCG.AmcpClient.Commands.Cg
{
    public abstract class AbstractCgCommandNoCgLayer : AbstractCgCommandNoCglayer<AmcpResponse>
    {

    }

    public abstract class AbstractCgCommandNoCglayer<TResponse> : AbstractChannelCommand<TResponse>
        where TResponse : AmcpResponse, new()
    {
        internal override string CommandName { get; } = "CG";

        /// <summary>
        /// Video layer.
        /// </summary>
        [Range(0, 9999)]
        [IncludeIfNotEqual(nameof(Layer), 9999)]
        [CommandParameter("-{0}", true, 2)]
        public int? Layer { get; set; }

        [Required]
        [CommandParameter(3)]
        internal abstract string CgCommandName { get; }
    }
}