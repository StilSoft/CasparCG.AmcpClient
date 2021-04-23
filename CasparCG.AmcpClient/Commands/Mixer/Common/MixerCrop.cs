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
    public class MixerCrop
    {
        private const string CultureName = "en-US";

        /// <summary>
        /// A value between 0 and 1 defining how far into the layer to crop from the left edge.
        /// </summary>
        [Required]
        [Range(0.0, 1.0)]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? LeftEdge { get; set; }

        /// <summary>
        /// A value between 0 and 1 defining how far into the layer to crop from the top edge.
        /// </summary>
        [Required]
        [Range(0.0, 1.0)]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? TopEdge { get; set; }

        /// <summary>
        /// A value between 1 and 0 defining how far into the layer to crop from the right edge.
        /// </summary>
        [Required]
        [Range(0.0, 1.0)]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? RightEdge { get; set; }

        /// <summary>
        /// A value between 1 and 0 defining how far into the layer to crop from the bottom edge.
        /// </summary>
        [Required]
        [Range(0.0, 1.0)]
        [NumberToStringCulture(CultureName)]
        [CommandParameter]
        public double? BottomEdge { get; set; }


        /// <param name="leftEdge"><see cref="LeftEdge"/></param>
        /// <param name="topEdge"><see cref="TopEdge"/></param>
        /// <param name="rightEdge"><see cref="RightEdge"/></param>
        /// <param name="bottomEdge"><see cref="BottomEdge"/></param>
        public MixerCrop(double? leftEdge = null, double? topEdge = null, double? rightEdge = null, double? bottomEdge = null)
        {
            LeftEdge = leftEdge;
            TopEdge = topEdge;
            RightEdge = rightEdge;
            BottomEdge = bottomEdge;
        }
    }
}