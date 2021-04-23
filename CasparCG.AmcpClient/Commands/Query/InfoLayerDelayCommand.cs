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
    /// Get the current delay on a layer.
    /// </summary>
    public class InfoLayerDelayCommand : AbstractInfoLayerCommandWithSubCommand<InfoLayerDelayCommandResponse>
    {
        // INFO 
        // [video_channel:int]
        // {
        //     -[layer:int]
        // } 
        // DELAY

        internal override string CommandName { get; } = "INFO";

        internal override string SubCommandName { get; } = "DELAY";


        public InfoLayerDelayCommand(int? channel = null, int? layer = null)
        {
            Channel = channel;
            Layer = layer;
        }       
    }
}