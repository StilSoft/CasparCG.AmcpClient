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
using StilSoft.CasparCG.AmcpClient.CommandBuilder.Attributes.Converters;
using StilSoft.CasparCG.AmcpClient.CommandBuilder.Attributes.Validations;
using StilSoft.CasparCG.AmcpClient.Commands.Query.Common.Response;
using System.ComponentModel.DataAnnotations;

namespace StilSoft.CasparCG.AmcpClient.Commands.Query
{
    /// <summary>
    /// Get information about a template.
    /// </summary>
    public class InfoTemplateCommand : AbstractInfoCommandWithSubCommand<InfoTemplateCommandResponse>
    {
        // INFO
        // TEMPLATE
        // [template:string]

        internal override string SubCommandName { get; } = "TEMPLATE";

        [Required]
        [IsValidFullName]
        [WindowsToUnixPath]
        [ValueToEscapedString]
        [CommandParameter("\"{0}\"")]
        public string TemplateFullName { get; set; }


        public InfoTemplateCommand(string templateFullName = "")
        {
            TemplateFullName = templateFullName;
        }
    }
}