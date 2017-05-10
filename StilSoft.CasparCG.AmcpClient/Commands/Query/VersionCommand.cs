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
using StilSoft.CasparCG.AmcpClient.Commands.Query.Common;
using StilSoft.CasparCG.AmcpClient.Commands.Query.Common.Response;
using System.ComponentModel.DataAnnotations;

namespace StilSoft.CasparCG.AmcpClient.Commands.Query
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