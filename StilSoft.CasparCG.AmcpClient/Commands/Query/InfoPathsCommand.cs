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
    /// Get information about the paths used.
    /// </summary>
    public class InfoPathsCommand : AbstractInfoCommand<InfoPathsCommandResponse>
    {
        // INFO
        // PATHS

        internal override string InfoCommandName { get; } = "PATHS";
    }
}