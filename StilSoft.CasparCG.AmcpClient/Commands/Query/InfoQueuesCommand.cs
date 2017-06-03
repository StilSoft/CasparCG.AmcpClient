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
    /// Get detailed information about all AMCP Command Queues.
    /// </summary>
    public class InfoQueuesCommand : AbstractInfoCommandWithSubCommand<InfoQueuesCommandResponse>
    {
        // INFO
        // QUEUES

        internal override string SubCommandName { get; } = "QUEUES";
    }
}