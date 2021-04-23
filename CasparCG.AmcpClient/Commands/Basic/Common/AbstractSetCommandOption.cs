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

namespace CasparCg.AmcpClient.Commands.Basic.Common
{
    [CommandBuilderObject]
    public abstract class AbstractSetCommandOption
    {
        [Required]
        [CommandParameter]
        internal abstract string OptionName { get; }
    }
}