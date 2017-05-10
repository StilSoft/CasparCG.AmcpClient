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
using StilSoft.CasparCG.AmcpClient.Common;
using System.ComponentModel.DataAnnotations;

namespace StilSoft.CasparCG.AmcpClient.Commands.Mixer
{
    public abstract class AbstractMixerChannelCommand : AbstractMixerChannelCommand<AmcpResponse>
    {

    }

    public abstract class AbstractMixerChannelCommand<TResponse> : AbstractChannelCommand<TResponse>
        where TResponse : AmcpResponse, new()
    {
        internal override string CommandName { get; } = "MIXER";

        [Required]
        [CommandParameter(2)]
        internal abstract string MixerCommandName { get; }
    }
}