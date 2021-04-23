//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////



namespace CasparCg.AmcpClient.Commands.Mixer
{
    /// <summary>
    /// Clear all transformations on a channel or layer.
    /// </summary>
    public class MixerClearCommand : AbstractMixerLayerCommandWithSubCommand
    {
        // MIXER
        // [video_channel:int]
        // {
        //     -[layer:int]
        // }
        // CLEAR 

        internal override string SubCommandName { get; } = "CLEAR";


        public MixerClearCommand(int? channel = null, int? layer = null)
        {
            Channel = channel;
            Layer = layer;
        }
    }
}