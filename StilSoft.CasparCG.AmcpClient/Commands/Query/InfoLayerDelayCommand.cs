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
    /// Get the current delay on a layer.
    /// </summary>
    public class InfoLayerDelayCommand : AbstractChannelCommand<InfoLayerDelayCommandResponse>
    {
        // INFO 
        // [video_channel:int]
        // {
        //     -[layer:int]
        // } 
        // DELAY

        internal override string CommandName { get; } = "INFO";

        /// <summary>
        /// Video layer.
        /// </summary>
        [Required]
        [Range(0, 9999)]
        [CommandParameter("-{0}", true)]
        public int? Layer { get; set; }

        [CommandParameter]
        public string InfoCommandName { get; } = "DELAY";


        public InfoLayerDelayCommand(int? channel = null, int? layer = null)
        {
            Channel = channel;
            Layer = layer;
        }
    }
}