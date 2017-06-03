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
    /// Get the perspective transform of a layer.
    /// </summary>
    public class MixerPerspectiveGetCommand : AbstractMixerLayerCommandWithSubCommand<MixerPerspectiveGetCommandResponse>
    {
        // MIXER
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // } 
        // PERSPECTIVE 

        internal override string SubCommandName { get; } = "PERSPECTIVE";


        public MixerPerspectiveGetCommand(int? channel = null, int? layer = null)
        {
            Channel = channel;
            Layer = layer;
        }
    }
}