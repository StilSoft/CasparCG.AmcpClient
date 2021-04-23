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

namespace CasparCg.AmcpClient.Commands.Mixer
{
    public abstract class AbstractMixerLayerCommandWithSubCommand : AbstractMixerLayerCommandWithSubCommand<AmcpResponse>
    {

    }

    public abstract class AbstractMixerLayerCommandWithSubCommand<TResponse> : AbstractLayerCommandWithSubCommand<TResponse>
        where TResponse : AmcpResponse, new()
    {
        internal override string CommandName { get; } = "MIXER";
    }
}