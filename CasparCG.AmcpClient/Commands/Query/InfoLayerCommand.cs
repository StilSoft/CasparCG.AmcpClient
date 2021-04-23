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
    /// Get information about a layer.
    /// </summary>
    public class InfoLayerCommand : AbstractInfoLayerCommand<InfoLayerCommandResponse>
    {
        // INFO
        // [video_channel:int]
        // {
        //     -[layer:int]
        // }

        internal override string CommandName { get; } = "INFO";


        public InfoLayerCommand(int? channel = null, int? layer = null)
        {
            Channel = channel;
            Layer = layer;
        }
    }
}