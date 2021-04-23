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
    /// Get information about a running template or the template host.
    /// </summary>
    public class CgInfoCommand : AbstractCgCommandWithSubCommandNoCgLayer
    {
        // CG
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-9999
        // }
        // INFO
        // {
        //     [cg_layer:int]
        // }

        // TODO implement response

        internal override string SubCommandName { get; } = "INFO";

        [Range(0, 9999)]
        [CommandParameter(4)]
        public int? CgLayer { get; set; }


        public CgInfoCommand(int? channel = null, int? layer = null, int? cgLayer = null)
        {
            Channel = channel;
            Layer = layer;
            CgLayer = cgLayer;
        }
    }
}