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

namespace StilSoft.CasparCG.AmcpClient.Commands.Data
{
    /// <summary>
    /// List stored datasets.
    /// </summary>
    public class DataListCommand : AbstractDataCommand<DataListCommandResponse>
    {
        // DATA LIST
        // {
        //     [sub_directory:string]
        // }

        internal override string DataCommandName { get; } = "LIST";

        [IsValidPath]
        [WindowsToUnixPath]
        [ValueToEscapedString]
        [CommandParameter("\"{0}\"")]
        public string SubDirectory { get; set; }


        public DataListCommand(string subDirectory = "")
        {
            SubDirectory = subDirectory;
        }
    }
}