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
    /// Lists all known threads in the server.
    /// </summary>
    public class InfoThreadsCommand : AbstractInfoCommandWithSubCommand<InfoThreadsCommandResponse>
    {
        // INFO
        // THREADS

        internal override string SubCommandName { get; } = "THREADS";
    }
}