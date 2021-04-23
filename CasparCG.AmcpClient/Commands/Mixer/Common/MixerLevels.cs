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
    public class MixerLevels
    {
        private const string CultureName = "en-US";

        /// <summary>
        /// Defines the input range (between 0 and 1) to accept RGB values within.
        /// </summary>
        [Required]
        [Range(0.0, 1.0)]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? MinimumInput { get; set; }

        /// <summary>
        /// Defines the input range (between 0 and 1) to accept RGB values within.
        /// </summary>
        [Required]
        [Range(0.0, 1.0)]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? MaximumInput { get; set; }

        /// <summary>
        /// Adjusts the gamma of the image.
        /// </summary>
        [Required]
        [Range(0.0, 1.0)]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? Gamma { get; set; }

        /// <summary>
        /// Defines the output range (between 0 and 1) to scale the accepted input RGB values to.
        /// </summary>
        [Required]
        [Range(0.0, 1.0)]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? MinimumOutput { get; set; }

        /// <summary>
        /// Defines the output range (between 0 and 1) to scale the accepted input RGB values to.
        /// </summary>
        [Required]
        [Range(0.0, 1.0)]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? MaximumOutput { get; set; }


        /// <param name="minimumInput"><see cref="MinimumInput"/></param>
        /// <param name="maximumInput"><see cref="MaximumInput"/></param>
        /// <param name="gamma"><see cref="Gamma"/></param>
        /// <param name="minimumOutput"><see cref="MinimumOutput"/></param>
        /// <param name="maximumOutput"><see cref="MaximumOutput"/></param>
        public MixerLevels(double? minimumInput = null, double? maximumInput = null, double? gamma = null,
                           double? minimumOutput = null, double? maximumOutput = null)
        {
            MinimumInput = minimumInput;
            MaximumInput = maximumInput;
            Gamma = gamma;
            MinimumOutput = minimumOutput;
            MaximumOutput = maximumOutput;
        }
    }
}