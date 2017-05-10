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

namespace StilSoft.CasparCG.AmcpClient.Commands.Query
{
    /// <summary>
    /// List media files.
    /// </summary>
    public class ClsCommand : AbstractBaseCommand<ClsCommandResponse>
    {
        // CLS
        // {
        //     [sub_directory:string]
        // }
        
        internal override string CommandName { get; } = "CLS";

        [IsValidPath]
        [WindowsToUnixPath]
        [ValueToEscapedString]
        [CommandParameter("\"{0}\"")]
        public string SubDirectory { get; set; }


        public ClsCommand(string subDirectory = null)
        {
            SubDirectory = subDirectory;
        }
    }
}