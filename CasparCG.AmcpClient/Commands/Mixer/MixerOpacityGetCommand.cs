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
    /// Get the opacity of a layer.
    /// </summary>
    public class MixerOpacityGetCommand : AbstractMixerLayerCommandWithSubCommand<MixerOpacityGetCommandResponse>
    {
        // MIXER
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // } 
        // OPACITY 

        internal override string SubCommandName { get; } = "OPACITY";


        public MixerOpacityGetCommand(int? channel = null, int? layer = null)
        {
            Channel = channel;
            Layer = layer;
        }
    }
}