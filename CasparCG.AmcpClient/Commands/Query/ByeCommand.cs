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
    /// Disconnect the session.
    /// </summary>
    public class ByeCommand : AbstractBaseCommand
    {
        // BYE

        internal override string CommandName { get; } = "BYE";
    }
}