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
using CasparCg.AmcpClient.Commands.Query.Common;
using CasparCg.AmcpClient.Commands.Query.Common.Response;

namespace CasparCg.AmcpClient.Commands.Query
{
    /// <summary>
    /// Get version information.
    /// </summary>
    public class VersionCommand : AbstractBaseCommand<VersionCommandResponse>
    {
        // VERSION 
        // {
        //     [component:string]
        // }

        internal override string CommandName { get; } = "VERSION";

        [Required]
        [EnumDataType(typeof(Component))]
        [CommandParameter]
        public Component? Component { get; set; }


        public VersionCommand(Component? component = null)
        {
            Component = component;
        }
    }
}