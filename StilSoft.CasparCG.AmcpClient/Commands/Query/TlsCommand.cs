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
    /// List templates.
    /// </summary>
    public class TlsCommand : AbstractBaseCommand<TlsCommandResponse>
    {
        // TLS
        // {
        //     [sub_directory:string]
        // }
        
        internal override string CommandName { get; } = "TLS";

        [IsValidPath]
        [WindowsToUnixPath]
        [ValueToEscapedString]
        [CommandParameter("\"{0}\"")]
        public string SubDirectory { get; set; }


        public TlsCommand(string subDirectory = null)
        {
            SubDirectory = subDirectory;
        }
    }
}