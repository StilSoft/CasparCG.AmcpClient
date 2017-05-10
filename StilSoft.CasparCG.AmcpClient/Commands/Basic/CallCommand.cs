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
using System.ComponentModel.DataAnnotations;

namespace StilSoft.CasparCG.AmcpClient.Commands.Basic
{
    /// <summary>
    /// Call a method on a producer.
    /// </summary>
    public class CallCommand : AbstractLayerCommand
    {
        // CALL
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-0
        // }
        // [param:string]

        // TODO - is not complete implemented ???

        internal override string CommandName { get; } = "CALL";

        [Required]
        [CommandParameter]
        public string Parameters { get; set; }


        public CallCommand(int? channel = null, int? layer = null, string parameters = "")
        {
            Channel = channel;
            Layer = layer;
            Parameters = parameters;
        }
    }
}