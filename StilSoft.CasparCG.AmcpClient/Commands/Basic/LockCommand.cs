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
using StilSoft.CasparCG.AmcpClient.CommandBuilder.Attributes.Conditions;
using StilSoft.CasparCG.AmcpClient.Commands.Basic.Common;
using System.ComponentModel.DataAnnotations;

namespace StilSoft.CasparCG.AmcpClient.Commands.Basic
{
    /// <summary>
    /// Lock or unlock access to a channel.
    /// </summary>
    public class LockCommand : AbstractChannelCommand
    {
        // LOCK
        // [video_channel:int]
        // [action:ACQUIRE,RELEASE,CLEAR]
        // {
        //     [lock-phrase:string]
        // }

        internal override string CommandName { get; } = "LOCK";

        [Required]
        [EnumDataType(typeof(LockAction))]
        [CommandParameter]
        public LockAction? LockAction { get; set; }

        [IncludeIfEqualOr(nameof(LockAction), Common.LockAction.Acquire)]
        [IncludeIfEqualOr(nameof(LockAction), Common.LockAction.Clear)]
        [CommandParameter]
        public string LockPhrase { get; set; }

       
        public LockCommand(int? channel = null, LockAction? action = null, string lockPhrase = "")
        {
            Channel = channel;
            LockAction = action;
            LockPhrase = lockPhrase;
        }
    }
}