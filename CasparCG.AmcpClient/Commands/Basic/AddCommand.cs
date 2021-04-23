//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using System.ComponentModel.DataAnnotations;
using CasparCg.AmcpClient.CommandBuilder.Attributes;

namespace CasparCg.AmcpClient.Commands.Basic
{
    /// <summary>
    /// Add a consumer to a video channel.
    /// </summary>
    public class AddCommand : AbstractChannelCommand
    {
        // ADD
        // [video_channel:int]
        // {
        //     -[consumer_index:int]
        // }
        // [consumer:string] // TODO consumers enum ?
        // [parameters:string]

        internal override string CommandName { get; } = "ADD";

        [Range(0, 9999)]
        [CommandParameter("-{0}", true)]
        public int? ConsumerIndex { get; set; }

        [Required]
        [CommandParameter]
        public string Consumer { get; set; }

        [CommandParameter]
        public string Parameters { get; set; }


        public AddCommand(int? channel = null, string consumer = null, string parameters = "") : this(channel, null, consumer, parameters)
        {

        }

        public AddCommand(int? channel = null, int? consumerIndex = null, string consumer = null, string parameters = "")
        {
            Channel = channel;
            ConsumerIndex = consumerIndex;
            Consumer = consumer;
            Parameters = parameters;
        }
    }
}