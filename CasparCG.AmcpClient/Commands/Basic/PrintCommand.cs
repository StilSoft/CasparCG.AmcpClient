//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////



namespace CasparCg.AmcpClient.Commands.Basic
{
    /// <summary>
    /// Take a snapshot of a channel.
    /// </summary>
    public class PrintCommand : AbstractChannelCommand
    {
        // PRINT
        // [video_channel:int]

        internal override string CommandName { get; } = "PRINT";


        public PrintCommand(int? channel = null)
        {
            Channel = channel;
        }
    }
}