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

namespace CasparCg.AmcpClient.Commands.Data
{
    /// <summary>
    /// Remove a stored dataset.
    /// </summary>
    public class DataRemoveCommand : AbstractDataCommandWithSubCommand
    {
        // DATA REMOVE
        // [name:string]

        internal override string SubCommandName { get; } = "REMOVE";

        [Required]
        [IsValidFullName]
        [WindowsToUnixPath]
        [ValueToEscapedString]
        [CommandParameter("\"{0}\"")]
        public string DataFullName { get; set; }


        public DataRemoveCommand(string dataFullName = "")
        {
            DataFullName = dataFullName;
        }
    }
}