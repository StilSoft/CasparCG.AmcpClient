//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////



namespace CasparCg.AmcpClient.Commands.Query
{
    /// <summary>
    /// Shutdown the server with restart exit code.
    /// </summary>
    public class RestartCommand : AbstractBaseCommand
    {
        // RESTART

        internal override string CommandName { get; } = "RESTART";
    }
}