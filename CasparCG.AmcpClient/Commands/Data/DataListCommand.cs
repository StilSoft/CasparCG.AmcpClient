//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using CasparCg.AmcpClient.CommandBuilder.Attributes;
using CasparCg.AmcpClient.CommandBuilder.Attributes.Converters;
using CasparCg.AmcpClient.CommandBuilder.Attributes.Validations;
using CasparCg.AmcpClient.Commands.Data.Common.Reponse;

namespace CasparCg.AmcpClient.Commands.Data
{
    /// <summary>
    /// List stored datasets.
    /// </summary>
    public class DataListCommand : AbstractDataCommandWithSubCommand<DataListCommandResponse>
    {
        // DATA LIST
        // {
        //     [sub_directory:string]
        // }

        internal override string SubCommandName { get; } = "LIST";

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