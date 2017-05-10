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
    /// Remove all templates on a video layer.
    /// </summary>
    public class CgClearCommand : AbstractCgCommandNoCgLayer
    {
        // CG
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-9999
        // }
        // CLEAR

        internal override string CgCommandName { get; } = "CLEAR";


        public CgClearCommand(int? channel = null, int? layer = null)
        {
            Channel = channel;
            Layer = layer;
        }
    }
}