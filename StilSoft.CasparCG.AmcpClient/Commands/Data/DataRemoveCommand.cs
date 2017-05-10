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
using System.ComponentModel.DataAnnotations;

namespace StilSoft.CasparCG.AmcpClient.Commands.Data
{
    /// <summary>
    /// Remove a stored dataset.
    /// </summary>
    public class DataRemoveCommand : AbstractDataCommand
    {
        // DATA REMOVE
        // [name:string]

        internal override string DataCommandName { get; } = "REMOVE";

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