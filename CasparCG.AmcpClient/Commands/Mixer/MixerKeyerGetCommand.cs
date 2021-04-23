//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using CasparCg.AmcpClient.Commands.Mixer.Common.Response;

namespace CasparCg.AmcpClient.Commands.Mixer
{
    /// <summary>
    /// Get state of a layer act as alpha for the one above.
    /// </summary>
    public class MixerKeyerGetCommand : AbstractMixerLayerCommandWithSubCommand<MixerKeyerGetCommandResponse>
    {
        // MIXER
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // }
        // KEYER
        // {
        //     keyer:0,1
        //     |0
        // }

        internal override string SubCommandName { get; } = "KEYER";


        public MixerKeyerGetCommand(int? channel = null, int? layer = null)
        {
            Channel = channel;
            Layer = layer;
        }
    }
}