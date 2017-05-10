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
using StilSoft.CasparCG.AmcpClient.Commands.Data.Common.Reponse;
using System.ComponentModel.DataAnnotations;

namespace StilSoft.CasparCG.AmcpClient.Commands.Data
{
    /// <summary>
    /// Retrieve a dataset.
    /// </summary>
    public class DataRetrieveCommand : AbstractDataCommand<DataRetrieveCommandResponse>
    {
        // DATA RETRIEVE
        // [name:string]

        internal override string DataCommandName { get; } = "RETRIEVE";

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