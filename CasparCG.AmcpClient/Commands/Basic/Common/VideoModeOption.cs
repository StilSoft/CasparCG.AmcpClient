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
using CasparCg.AmcpClient.Common.Enums;

namespace CasparCg.AmcpClient.Commands.Basic.Common
{
    public class VideoModeOption : AbstractSetCommandOption
    {
        internal override string OptionName { get; } = "MODE";

        [Required]
        [EnumDataType(typeof(VideoMode))]
        [EnumToString]
        [CommandParameter]
        public VideoMode? VideoMode { get; set; }


        public VideoModeOption(VideoMode? videoMode = null)
        {
            VideoMode = videoMode;
        }
    }
}