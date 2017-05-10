//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using StilSoft.CasparCG.AmcpClient.Commands.Query.Common.Response;

namespace StilSoft.CasparCG.AmcpClient.Commands.Query
{
    /// <summary>
    /// Get the contents of the configuration used.
    /// </summary>
    public class InfoConfigCommand : AbstractInfoCommand<InfoConfigCommandResponse>
    {
        // INFO
        // CONFIG

        internal override string InfoCommandName { get; } = "CONFIG";
    }
}