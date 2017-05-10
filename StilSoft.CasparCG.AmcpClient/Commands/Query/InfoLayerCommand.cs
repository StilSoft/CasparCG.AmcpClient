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
using StilSoft.CasparCG.AmcpClient.Commands.Query.Common.Response;
using System.ComponentModel.DataAnnotations;

namespace StilSoft.CasparCG.AmcpClient.Commands.Query
{
    /// <summary>
    /// Get information about a layer.
    /// </summary>
    public class InfoLayerCommand : AbstractChannelCommand<InfoLayerCommandResponse>
    {
        // INFO
        // [video_channel:int]
        // {
        //     -[layer:int]
        // }

        internal override string CommandName { get; } = "INFO";

        /// <summary>
        /// Video layer.
        /// </summary>
        [Required]
        [Range(0, 9999)]
        [CommandParameter("-{0}", true)]
        public int? Layer { get; set; }


        public InfoLayerCommand(int? channel = null, int? layer = null)
        {
            Channel = channel;
            Layer = layer;
        }
    }
}