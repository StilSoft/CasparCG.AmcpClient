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
    public class MixerAnchor
    {
        private const string CultureName = "en-US";

        /// <summary>
        /// The x anchor point, 0 = left edge of layer, 0.5 = middle of layer, 1.0 = right edge of layer. Higher and lower values allowed.
        /// </summary>
        [Required]
        [Range(0.0, 1.0)]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? XPosition { get; set; }

        /// <summary>
        /// The y anchor point, 0 = top edge of layer, 0.5 = middle of layer, 1.0 = bottom edge of layer. Higher and lower values allowed.
        /// </summary>
        [Required]
        [Range(0.0, 1.0)]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? YPosition { get; set; }


        /// <param name="xPosition"><see cref="XPosition"/></param>
        /// <param name="yPosition"><see cref="YPosition"/></param>
        public MixerAnchor(double? xPosition = null, double? yPosition = null)
        {
            XPosition = xPosition;
            YPosition = yPosition;
        }
    }
}