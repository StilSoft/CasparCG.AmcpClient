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
using CasparCg.AmcpClient.CommandBuilder.Attributes.Converters;
using CasparCg.AmcpClient.CommandBuilder.Attributes.Validations;
using CasparCg.AmcpClient.Commands.Query.Common.Response;

namespace CasparCg.AmcpClient.Commands.Query
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