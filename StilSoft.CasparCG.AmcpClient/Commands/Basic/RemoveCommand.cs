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
using System.ComponentModel.DataAnnotations;

namespace StilSoft.CasparCG.AmcpClient.Commands.Basic
{
    /// <summary>
    /// Remove a consumer from a video channel.
    /// </summary>
    public class RemoveCommand : AbstractChannelCommand
    {
        // REMOVE
        // [video_channel:int]
        // {
        //     -[consumer_index:int]
        // }
        // [consumer:string] // TODO consumers enum ?
        // {
        //     [parameters:string]
        // }

        internal override string CommandName { get; } = "REMOVE";

        [Range(0, 9999)]
        [IncludeIfNotIncluded(nameof(Consumer))]
        [CommandParameter("-{0}", true)]
        public int? ConsumerIndex { get; set; }

        [CommandParameter]
        public string Consumer { get; set; }
        
        [IncludeIfIncluded(nameof(Consumer))]
        [CommandParameter]
        public string Parameters { get; set; }


        public RemoveCommand(int? channel = null, string consumer = "", string parameters = "")
        {
            Channel = channel;
            Consumer = consumer;
            Parameters = parameters;
        }

        public RemoveCommand(int? channel = null, int? consumerIndex = null)
        {
            Channel = channel;
            ConsumerIndex = consumerIndex;
        }
    }
}