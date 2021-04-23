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

namespace CasparCg.AmcpClient.Commands.Mixer.Common
{
    public enum BlendMode
    {
        Normal,
        Lighten,
        Sarken,
        Multiply,
        Average,
        Add,
        Subtract,
        Difference,
        Negation,
        Exclusion,
        Screen,
        Overlay,
        [Description("Soft_light")]
        SoftLight,
        [Description("Hard_light")]
        HardLight,
        [Description("Color_dodge")]
        ColorDodge,
        [Description("Color_burn")]
        ColorBurn,
        [Description("Linear_dodge")]
        LinearDodge,
        [Description("Linear_burn")]
        LinearBurn,
        [Description("Linear_light")]
        LinearLight,
        [Description("Vivid_light")]
        VividLight,
        [Description("Pin_light")]
        PinLight,
        [Description("Hard_mix")]
        HardMix,
        Reflect,
        Glow,
        Phoenix,
        Contrast,
        Saturation,
        Color,
        Luminosity
    }
}