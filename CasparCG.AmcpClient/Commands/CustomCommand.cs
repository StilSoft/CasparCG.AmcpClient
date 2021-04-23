//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using CasparCg.AmcpClient.Common;

namespace CasparCg.AmcpClient.Commands
{
    /// <summary>
    /// Send custom command string
    /// </summary>
    public class CustomCommand : CustomCommand<AmcpResponse>
    {
        public CustomCommand(string commandString = "")
        {
            CommandString = commandString;
        }
    }

    /// <summary>
    /// Send custom command string with custom response
    /// </summary>
    public class CustomCommand<TResponse> : AbstractBaseCommand<TResponse>
        where TResponse : AmcpResponse, new()
    {
        internal override string CommandName => CommandString;

        public string CommandString { get; set; }


        public CustomCommand(string commandString = "")
        {
            CommandString = commandString;
        }
    }
}