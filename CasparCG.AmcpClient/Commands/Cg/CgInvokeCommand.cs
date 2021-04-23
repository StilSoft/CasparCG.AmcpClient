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

namespace CasparCg.AmcpClient.Commands.Cg
{
    /// <summary>
    /// Invoke a method/label on a template.
    /// </summary>
    public class CgInvokeCommand : AbstractCgCommandWithSubCommandWithCgLayer
    {
        // CG
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-9999
        // }
        // INVOKE
        // [cg_layer:int]
        // [method:string]

        internal override string SubCommandName { get; } = "INVOKE";

        [Required]
        [CommandParameter]
        public string Method { get; set; }
        

        public CgInvokeCommand(int? channel = null, int? layer = null, int? cgLayer = null, string method = "")
        {
            Channel = channel;
            Layer = layer;
            CgLayer = cgLayer;
            Method = method;
        }
    }
}