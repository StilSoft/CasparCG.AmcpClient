//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using CasparCg.AmcpClient.Commands.Query.Common.Response;

namespace CasparCg.AmcpClient.Commands.Query
{
    /// <summary>
    /// Get system information.
    /// </summary>
    public class InfoSystemCommand : AbstractInfoCommandWithSubCommand<InfoSystemCommandResponse>
    {
        // INFO
        // SYSTEM

        internal override string SubCommandName { get; } = "SYSTEM";
    }
}