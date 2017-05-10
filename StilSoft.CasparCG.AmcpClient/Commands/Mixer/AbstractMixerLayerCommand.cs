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
    public abstract class AbstractMixerLayerCommand : AbstractMixerLayerCommand<AmcpResponse>
    {

    }

    public abstract class AbstractMixerLayerCommand<TResponse> : AbstractLayerCommand<TResponse>
        where TResponse : AmcpResponse, new()
    {
        internal override string CommandName { get; } = "MIXER";

        [Required]
        [CommandParameter(3)]
        internal abstract string MixerCommandName { get; }
    }
}