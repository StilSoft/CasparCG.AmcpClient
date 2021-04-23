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
using CasparCg.AmcpClient.Commands.Data.Common.Reponse;

namespace CasparCg.AmcpClient.Commands.Data
{
    /// <summary>
    /// Retrieve a dataset.
    /// </summary>
    public class DataRetrieveCommand : AbstractDataCommandWithSubCommand<DataRetrieveCommandResponse>
    {
        // DATA RETRIEVE
        // [name:string]

        internal override string SubCommandName { get; } = "RETRIEVE";

        [Required]
        [IsValidFullName]
        [WindowsToUnixPath]
        [ValueToEscapedString]
        [CommandParameter("\"{0}\"")]
        public string DataFullName { get; set; }


        public DataRetrieveCommand(string dataFullName = "")
        {
            DataFullName = dataFullName;
        }
    }
}