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
    /// Trigger a "continue" in a template.
    /// </summary>
    public class CgNextCommand : AbstractCgCommandWithSubCommandWithCgLayer
    {
        // CG
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-9999
        // }
        // NEXT
        // [cg_layer:int]

        internal override string SubCommandName { get; } = "NEXT";


        public CgNextCommand(int? channel = null, int? layer = null, int? cgLayer = null)
        {
            Channel = channel;
            Layer = layer;
            CgLayer = cgLayer;
        }
    }
}