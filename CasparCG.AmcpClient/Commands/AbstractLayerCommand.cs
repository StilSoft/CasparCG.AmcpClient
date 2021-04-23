//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using System.ComponentModel.DataAnnotations;
using CasparCg.AmcpClient.CommandBuilder.Attributes;
using CasparCg.AmcpClient.Common;

namespace CasparCg.AmcpClient.Commands
{
    // Default response for all Channel and Layer commands.
    public abstract class AbstractLayerCommand : AbstractLayerCommand<AmcpResponse>
    {

    }

    public abstract class AbstractLayerCommand<TResponse> : AbstractChannelCommand<TResponse>
        where TResponse : AmcpResponse, new()
    {
        /// <summary>
        /// Video layer.
        /// </summary>
        [Range(0, 9999)]
        //[IncludeIfNotEqual(nameof(Layer), 0)]   // TODO We need to include this property (if is set) because some of the commands must include layer 0.
        [CommandParameter("-{0}", true, 2)]
        public virtual int? Layer { get; set; }
    }
}