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
    /// Get the volume of an entire channel.
    /// </summary>
    public class MixerMasterVolumeGetCommand : AbstractMixerChannelCommandWithSubCommand<MixerMasterVolumeGetCommandResponse>
    {
        // MIXER
        // [video_channel:int]
        // MASTERVOLUME 

        internal override string SubCommandName { get; } = "MASTERVOLUME";


        public MixerMasterVolumeGetCommand(int? channel = null)
        {
            Channel = channel;
        }
    }
}