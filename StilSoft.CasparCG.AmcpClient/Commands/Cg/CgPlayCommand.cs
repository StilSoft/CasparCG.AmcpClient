//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////



namespace StilSoft.CasparCG.AmcpClient.Commands.Cg
{
    /// <summary>
    /// Play and display a template.
    /// </summary>
    public class CgPlayCommand : AbstractCgCommand
    {
        // CG
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-9999
        // }
        // PLAY
        // [cg_layer:int]

        internal override string CgCommandName { get; } = "PLAY";


        public CgPlayCommand(int? channel = null, int? layer = null, int? cgLayer = null)
        {
            Channel = channel;
            Layer = layer;
            CgLayer = cgLayer;
        }
    }
}