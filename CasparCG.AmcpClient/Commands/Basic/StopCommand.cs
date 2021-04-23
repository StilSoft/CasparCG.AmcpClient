//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////



namespace CasparCg.AmcpClient.Commands.Basic
{
    /// <summary>
    /// Remove the foreground clip of a layer.
    /// </summary>
    public class StopCommand : AbstractLayerCommand
    {
        // STOP
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // }

        internal override string CommandName { get; } = "STOP";


        public StopCommand(int? channel = null, int? layer = null)
        {
            Channel = channel;
            Layer = layer;
        }
    }
}