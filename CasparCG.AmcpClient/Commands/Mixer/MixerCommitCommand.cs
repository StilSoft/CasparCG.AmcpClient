//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////



namespace CasparCg.AmcpClient.Commands.Mixer
{
    /// <summary>
    /// Commit all deferred mixer transforms.
    /// </summary>
    public class MixerCommitCommand : AbstractMixerChannelCommandWithSubCommand
    {
        // MIXER
        // [video_channel:int]
        // COMMIT 

        internal override string SubCommandName { get; } = "COMMIT";


        public MixerCommitCommand(int? channel = null)
        {
            Channel = channel;
        }
    }
}