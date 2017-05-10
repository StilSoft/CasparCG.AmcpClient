//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using StilSoft.CasparCG.AmcpClient.CommandBuilder.Attributes;
using StilSoft.CasparCG.AmcpClient.Commands.Basic.Common;
using System.ComponentModel.DataAnnotations;

namespace StilSoft.CasparCG.AmcpClient.Commands.Basic
{
    /// <summary>
    /// Change the value of a channel variable.
    /// </summary>
    public class SetCommand : AbstractChannelCommand
    {
        // SET
        // [video_channel:int]
        // [variable:string]
        // [value:string]

        internal override string CommandName { get; } = "SET";

        [Required]
        [CommandParameter]
        public AbstractSetCommandOption Option { get; set; }


        public SetCommand(int? channel = null, AbstractSetCommandOption option = null)
        {
            Channel = channel;
            Option = option;
        }
    }
}