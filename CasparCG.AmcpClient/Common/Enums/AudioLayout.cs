//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using System.ComponentModel;

namespace CasparCg.AmcpClient.Common.Enums
{
    public enum AudioLayout
    {
        [Description("mono")]
        LayoutMono,

        [Description("stereo")]
        LayoutStereo,

        [Description("matrix")]
        LayoutMatrix,

        [Description("film")]
        LayoutFilm,

        [Description("smpte")]
        LayoutSmpte,

        [Description("ebu_r123_8a")]
        LayoutEbuR123_8A,

        [Description("ebu_r123_8b")]
        LayoutEbuR123_8B,

        [Description("8ch")]
        Layout8Ch,

        [Description("16ch")]
        Layout16Ch
    }
}