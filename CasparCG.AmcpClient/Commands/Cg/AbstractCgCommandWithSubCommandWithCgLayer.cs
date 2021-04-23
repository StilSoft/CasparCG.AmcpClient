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

namespace CasparCg.AmcpClient.Commands.Cg
{
    public abstract class AbstractCgCommandWithSubCommandWithCgLayer : AbstractCgCommandWithSubCommandWithCgLayer<AmcpResponse>
    {

    }

    public abstract class AbstractCgCommandWithSubCommandWithCgLayer<TResponse> : AbstractCgCommandWithSubCommandNoCglayer<TResponse>
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