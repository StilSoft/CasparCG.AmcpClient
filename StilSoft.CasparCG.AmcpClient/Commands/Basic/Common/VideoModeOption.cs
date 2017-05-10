//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using StilSoft.CasparCG.AmcpClient.CommandBuilder.Attributes;
using StilSoft.CasparCG.AmcpClient.CommandBuilder.Attributes.Converters;
using StilSoft.CasparCG.AmcpClient.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace StilSoft.CasparCG.AmcpClient.Commands.Basic.Common
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