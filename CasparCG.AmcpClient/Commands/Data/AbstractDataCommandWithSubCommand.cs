//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using CasparCg.AmcpClient.Common;

namespace CasparCg.AmcpClient.Commands.Data
{
    public abstract class AbstractDataCommandWithSubCommand : AbstractDataCommandWithSubCommand<AmcpResponse>
    {

    }

    public abstract class AbstractDataCommandWithSubCommand<TResponse> : AbstractBaseCommandWithSubCommand<TResponse>
        where TResponse : AmcpResponse, new()
    {
        internal override string CommandName { get; } = "DATA";
    }
}