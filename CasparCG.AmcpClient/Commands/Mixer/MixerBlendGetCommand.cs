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
    /// Get the blend mode for a layer.
    /// </summary>
    public class MixerBlendGetCommand : AbstractMixerLayerCommandWithSubCommand<MixerBlendGetCommandResponse>
    {
        // MIXER
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // } 
        // BLEND 

        internal override string SubCommandName { get; } = "BLEND";


        public MixerBlendGetCommand(int? channel = null, int? layer = null)
        {
            Channel = channel;
            Layer = layer;
        }
    }
}