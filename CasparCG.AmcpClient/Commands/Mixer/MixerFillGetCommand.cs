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
    /// Get the fill position and scale of a layer.
    /// </summary>
    public class MixerFillGetCommand : AbstractMixerLayerCommandWithSubCommand<MixerFillGetCommandResponse>
    {
        // MIXER
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // } 
        // FILL 

        internal override string SubCommandName { get; } = "FILL";


        public MixerFillGetCommand(int? channel = null, int? layer = null)
        {
            Channel = channel;
            Layer = layer;
        }
    }
}