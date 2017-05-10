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
    /// Get the volume of an entire channel.
    /// </summary>
    public class MixerMasterVolumeGetCommand : AbstractMixerChannelCommand<MixerMasterVolumeGetCommandResponse>
    {
        // MIXER
        // [video_channel:int]
        // MASTERVOLUME 

        internal override string MixerCommandName { get; } = "MASTERVOLUME";


        public MixerMasterVolumeGetCommand(int? channel = null)
        {
            Channel = channel;
        }
    }
}