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

namespace StilSoft.CasparCG.AmcpClient.Commands.Cg
{
    public abstract class AbstractCgCommand : AbstractCgCommand<AmcpResponse>
    {

    }

    public abstract class AbstractCgCommand<TResponse> : AbstractCgCommandNoCglayer<TResponse>
        where TResponse : AmcpResponse, new()
    {
        /// <summary>
        /// Cg layer.
        /// </summary>
        [Required]
        [Range(0, 9999)]
        [CommandParameter(4)]
        public int? CgLayer { get; set; }
    }
}