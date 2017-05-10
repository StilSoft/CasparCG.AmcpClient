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
    /// Store a dataset.
    /// </summary>
    public class DataStoreCommand : AbstractDataCommand
    {
        // DATA STORE
        // [name:string]
        // [data:string]

        internal override string DataCommandName { get; } = "STORE";

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