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
    /// Get the chroma keying on a layer.
    /// </summary>
    public class MixerChromaGetCommand : AbstractMixerLayerCommand<MixerChromaGetCommandResponse>
    {
        // MIXER 
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // }
        // CHROMA

        internal override string MixerCommandName { get; } = "CHROMA";


        public MixerChromaGetCommand(int? channel = null, int? layer = null)
        {
            Channel = channel;
            Layer = layer;
        }
    }
}