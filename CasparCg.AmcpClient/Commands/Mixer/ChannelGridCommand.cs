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
    /// Open a new channel displaying a grid with the contents of all the existing channels.
    /// </summary>
    /// <remarks>
    /// The element "<![CDATA[<channel-grid>true</channel-grid>]]>" must be present in "casparcg.config" for this to work correctly.
    /// </remarks>
    public class ChannelGridCommand : AbstractBaseCommand
    {
        internal override string CommandName { get; } = "CHANNEL_GRID";
    }
}