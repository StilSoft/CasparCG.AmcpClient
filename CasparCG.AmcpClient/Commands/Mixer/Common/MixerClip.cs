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
    public class MixerClip
    {
        private const string CultureName = "en-US";

        /// <summary>
        /// The new x position, 0 = left edge of monitor, 0.5 = middle of monitor, 1.0 = right edge of monitor. Higher and lower values allowed.
        /// </summary>
        [Required]
        [Range(0.0, 1.0)]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? XPosition { get; set; }

        /// <summary>
        /// The new y position, 0 = top edge of monitor, 0.5 = middle of monitor, 1.0 = bottom edge of monitor. Higher and lower values allowed.
        /// </summary>
        [Required]
        [Range(0.0, 1.0)]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? YPosition { get; set; }

        /// <summary>
        /// The new width, 1 = 1x the screen width, 0.5 = half the screen width. Higher and lower values allowed. Negative values flips the layer.
        /// </summary>
        [Required]
        [Range(0.0, 1.0)]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? Width { get; set; }

        /// <summary>
        /// The new height, 1 = 1x the screen height, 0.5 = half the screen height. Higher and lower values allowed. Negative values flips the layer.
        /// </summary>
        [Required]
        [Range(0.0, 1.0)]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? Height { get; set; }


        /// <param name="xPosition"><see cref="XPosition"/></param>
        /// <param name="yPosition"><see cref="YPosition"/></param>
        /// <param name="width"><see cref="Width"/></param>
        /// <param name="height"><see cref="Height"/></param>
        public MixerClip(double? xPosition = null, double? yPosition = null, double? width = null, double? height = null)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            Width = width;
            Height = height;
        }
    }
}