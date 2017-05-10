//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using StilSoft.CasparCG.AmcpClient.Commands.Mixer.Common.Response;

namespace StilSoft.CasparCG.AmcpClient.Commands.Mixer
{
    /// <summary>
    /// Get the brightness of a layer.
    /// </summary>
    public class MixerBrightnessGetCommand : AbstractMixerLayerCommand<MixerBrightnessGetCommandResponse>
    {
        // MIXER
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // } 
        // BRIGHTNESS 

        internal override string MixerCommandName { get; } = "BRIGHTNESS";


        public MixerBrightnessGetCommand(int? channel = null, int? layer = null)
        {
            Channel = channel;
            Layer = layer;
        }
    }
}