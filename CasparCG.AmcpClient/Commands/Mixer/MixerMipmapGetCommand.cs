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
    /// Get the mipmapping for a layer.
    /// </summary>
    public class MixerMipmapGetCommand : AbstractMixerLayerCommandWithSubCommand<MixerMipmapGetCommandResponse>
    {
        // MIXER 
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // } 
        // MIPMAP 
        // {
        //     [mipmap:0,1]
        //     |0
        // }

        internal override string SubCommandName { get; } = "MIPMAP";


        public MixerMipmapGetCommand(int? channel = null, int? layer = null)
        {
            Channel = channel;
            Layer = layer;
        }
    }
}