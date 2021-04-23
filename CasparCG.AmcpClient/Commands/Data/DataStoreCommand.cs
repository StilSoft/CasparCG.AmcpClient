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
    /// Store a dataset.
    /// </summary>
    public class DataStoreCommand : AbstractDataCommandWithSubCommand
    {
        // DATA STORE
        // [name:string]
        // [data:string]

        internal override string SubCommandName { get; } = "STORE";

        [Required]
        [IsValidFullName]
        [WindowsToUnixPath]
        [ValueToEscapedString]
        [CommandParameter("\"{0}\"")]
        public string DataFullName { get; set; }

        [ValueToEscapedString]
        [CommandParameter("\"{0}\"")]
        public string Data { get; set; }


        public DataStoreCommand(string dataFullName = "", string data = "")
        {
            DataFullName = dataFullName;
            Data = data;
        }
    }
}