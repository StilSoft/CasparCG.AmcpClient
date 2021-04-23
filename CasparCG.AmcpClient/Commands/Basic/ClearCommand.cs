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
    /// Remove all clips of a layer or an entire channel.
    /// </summary>
    public class ClearCommand : AbstractLayerCommand
    {
        // CLEAR
        // [video_channel:int]
        // {
        //     -[layer:int]
        // }

        internal override string CommandName { get; } = "CLEAR";


        public ClearCommand(int? channel = null, int? layer = null)
        {
            Channel = channel;
            Layer = layer;
        }
    }
}