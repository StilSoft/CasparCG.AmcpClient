//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////



namespace StilSoft.CasparCG.AmcpClient.Commands.Mixer
{
    /// <summary>
    /// Commit all deferred mixer transforms.
    /// </summary>
    public class MixerCommitCommand : AbstractMixerChannelCommand
    {
        // MIXER
        // [video_channel:int]
        // COMMIT 

        internal override string MixerCommandName { get; } = "COMMIT";


        public MixerCommitCommand(int? channel = null)
        {
            Channel = channel;
        }
    }
}