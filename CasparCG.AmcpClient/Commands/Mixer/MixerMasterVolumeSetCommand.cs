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

namespace CasparCg.AmcpClient.Commands.Mixer
{
    /// <summary>
    /// Change the volume of an entire channel.
    /// </summary>
    public class MixerMasterVolumeSetCommand : AbstractMixerChannelCommandWithSubCommand
    {
        // MIXER
        // [video_channel:int]
        // MASTERVOLUME 
        // {
        //     [volume:float] 
        // }

        internal override string SubCommandName { get; } = "MASTERVOLUME";

        [Required]
        [Range(0.0, 10.0)]
        [NumberToStringCulture("en-US")]
        [CommandParameter]
        public double? Volume { get; set; }


        public MixerMasterVolumeSetCommand(int? channel = null, double? volume = null)
        {
            Channel = channel;
            Volume = volume;
        }
    }
}