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
    public class MixerPerspective
    {
        // TODO check ranges and set default values ??
        private const string CultureName = "en-US";

        /// <summary>
        /// Defines the x coordinate of the top left corner.
        /// </summary>
        [Required]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? TopLeftX { get; set; }

        /// <summary>
        /// Defines the x coordinate of the top left corner.
        /// </summary>
        [Required]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? TopLeftY { get; set; }

        /// <summary>
        /// Defines the x coordinate of the top right corner.
        /// </summary>
        [Required]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? TopRightX { get; set; }

        /// <summary>
        /// Defines the y coordinate of the top right corner.
        /// </summary>
        [Required]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? TopRightY { get; set; }

        /// <summary>
        /// Defines the x coordinate of the bottom right corner.
        /// </summary>
        [Required]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? BottomRightX { get; set; }

        /// <summary>
        /// Defines the y coordinate of the bottom right corner.
        /// </summary>
        [Required]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? BottomRightY { get; set; }

        /// <summary>
        /// Defines the x coordinate of the bottom left corner.
        /// </summary>
        [Required]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? BottomLeftX { get; set; }

        /// <summary>
        /// Defines the y coordinate of the bottom left corner.
        /// </summary>
        [Required]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? BottomLeftY { get; set; }


        /// <param name="topLeftX"><see cref="TopLeftX"/></param>
        /// <param name="topLeftY"><see cref="TopLeftY"/></param>
        /// <param name="topRightX"><see cref="TopRightX"/></param>
        /// <param name="topRightY"><see cref="TopRightY"/></param>
        /// <param name="bottomRightX"><see cref="BottomRightX"/></param>
        /// <param name="bottomRightY"><see cref="BottomRightY"/></param>
        /// <param name="bottomLeftX"><see cref="BottomLeftX"/></param>
        /// <param name="bottomLeftY"><see cref="BottomLeftY"/></param>
        public MixerPerspective(double? topLeftX = null, double? topLeftY = null, double? topRightX = null, double? topRightY = null,
                                double? bottomRightX = null, double? bottomRightY = null, double? bottomLeftX = null, double? bottomLeftY = null)
        {
            TopLeftX = topLeftX;
            TopLeftY = topLeftY;
            TopRightX = topRightX;
            TopRightY = topRightY;
            BottomRightX = bottomRightX;
            BottomRightY = bottomRightY;
            BottomLeftX = bottomLeftX;
            BottomLeftY = bottomLeftY;
        }
    }
}