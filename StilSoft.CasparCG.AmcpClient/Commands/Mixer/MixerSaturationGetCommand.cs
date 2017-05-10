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
    /// Get the saturation of a layer.
    /// </summary>
    public class MixerSaturationGetCommand : AbstractMixerLayerCommand<MixerSaturationGetCommandResponse>
    {
        // MIXER
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // } 
        // SATURATION 

        internal override string MixerCommandName { get; } = "SATURATION";


        public MixerSaturationGetCommand(int? channel = null, int? layer = null)
        {
            Channel = channel;
            Layer = layer;
        }
    }
}