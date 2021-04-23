//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////



namespace CasparCg.AmcpClient.Commands.Cg
{
    /// <summary>
    /// Stop and remove a template.
    /// </summary>
    public class CgStopCommand : AbstractCgCommandWithSubCommandWithCgLayer
    {
        // CG 
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-9999
        // }
        // STOP
        // [cg_layer:int]

        internal override string SubCommandName { get; } = "STOP";


        public CgStopCommand(int? channel = null, int? layer = null, int? cgLayer = null)
        {
            Channel = channel;
            Layer = layer;
            CgLayer = cgLayer;
        }
    }
}