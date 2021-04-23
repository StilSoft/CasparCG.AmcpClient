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
using CasparCg.AmcpClient.CommandBuilder.Attributes.Converters;

namespace CasparCg.AmcpClient.Commands.Mixer.Common
{
    [CommandBuilderObject]
    public class MixerChroma
    {
        // [target_hue:float] 
        // [hue_width:float] 
        // [min_saturation:float]
        // [min_brightness:float]
        // [softness:float]
        // [spill_suppress:float]
        // [spill_suppress_saturation:float]
        // [show_mask:0,1]

        private const string CultureName = "en-US";

        /// <summary>
        /// The hue in degrees between 0-360 where the center of the hue window will open up.
        /// </summary>
        [Required]
        [Range(0.0, 360.0)]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? TargetHue { get; set; }

        /// <summary>
        /// The width of the hue window within 0.0-1.0 where 1.0 means 100% of 360 degrees around target_hue.
        /// </summary>
        [Required]
        [Range(0.0, 1.0)]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? HueWidth { get; set; }

        /// <summary>
        /// The minimum saturation within 0.0-1.0 required for a color to be within the chroma window.   
        /// </summary>
        [Required]
        [Range(0.0, 1.0)]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? MinSaturation { get; set; }

        /// <summary>
        /// The minimum brightness within 0.0-1.0 required for a color to be within the chroma window.
        /// </summary>
        [Required]
        [Range(0.0, 1.0)]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? MinBrightness { get; set; }

        /// <summary>
        /// The softness of the chroma keying window.        
        /// </summary>
        [Required]
        [Range(0.0, 1.0)]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? Softness { get; set; }

        /// <summary>
        /// How much to suppress spill by within 0.0-180.0. It works by taking all hue values within +- this value from target_hue and clamps it to either target_hue - this value or target_hue + this value depending on which side it is closest to.
        /// </summary>
        [Required]
        [Range(0.0, 180.0)]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? SpillSuppress { get; set; }

        /// <summary>
        /// Controls how much saturation should be kept on colors affected by spill_suppress within 0.0-1.0. Full saturation may not always be desirable to be kept on suppressed colors.
        /// </summary>
        [Required]
        [Range(0.0, 1.0)]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? SpillSuppressSaturation { get; set; }

        /// <summary>
        /// If enabled, only shows the mask. Useful while editing the chroma key settings.
        /// </summary>
        [Required]
        [BooleanToString("1", "0")]
        [CommandParameter]
        public bool? ShowMask { get; set; }


        /// <param name="targetHue"><see cref="TargetHue"/></param>
        /// <param name="hueWidth"><see cref="HueWidth"/></param>
        /// <param name="minSaturation"><see cref="MinSaturation"/></param>
        /// <param name="minBrightness"><see cref="MinBrightness"/></param>
        /// <param name="softness"><see cref="Softness"/></param>
        /// <param name="spillSuppress"><see cref="SpillSuppress"/></param>
        /// <param name="spillSuppressSaturation"><see cref="SpillSuppressSaturation"/></param>
        /// <param name="showMask"><see cref="ShowMask"/></param>
        public MixerChroma(double? targetHue = null, double? hueWidth = null, double? minSaturation = null, double? minBrightness = null, 
                         double? softness = null, double? spillSuppress = null, double? spillSuppressSaturation = null, bool? showMask = null)
        {
            TargetHue = targetHue;
            HueWidth = hueWidth;
            MinSaturation = minSaturation;
            MinBrightness = minBrightness;
            Softness = softness;
            SpillSuppress = spillSuppress;
            SpillSuppressSaturation = spillSuppressSaturation;
            ShowMask = showMask;
        }
    }
}