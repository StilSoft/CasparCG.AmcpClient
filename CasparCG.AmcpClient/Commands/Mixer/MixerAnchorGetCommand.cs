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
    /// Get the anchor point of a layer.
    /// </summary>
    public class MixerAnchorGetCommand : AbstractMixerLayerCommandWithSubCommand<MixerAnchorGetCommandResponse>
    {
        // MIXER
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // } 
        // ANCHOR 

        internal override string SubCommandName { get; } = "ANCHOR";


        public MixerAnchorGetCommand(int? channel = null, int? layer = null)
        {
            Channel = channel;
            Layer = layer;
        }
    }
}