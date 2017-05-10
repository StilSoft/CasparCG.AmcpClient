//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using StilSoft.CasparCG.AmcpClient.Abstracts.Command;
using StilSoft.CasparCG.AmcpClient.CommandBuilder;
using StilSoft.CasparCG.AmcpClient.CommandBuilder.Attributes;
using StilSoft.CasparCG.AmcpClient.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace StilSoft.CasparCG.AmcpClient.Commands
{
    // Default response for all commands.
    public abstract class AbstractBaseCommand : AbstractBaseCommand<AmcpResponse>
    {

    }

    [CommandBuilderObject]
    public abstract class AbstractBaseCommand<TResponse> : AbstractCommand<AmcpPacket, AmcpParser, AmcpParsedData, TResponse>
        where TResponse : AmcpResponse, new()
    {
        [Required]
        [CommandParameter(0)]
        internal abstract string CommandName { get; }

        internal bool DontCheckServerVersion { get; set; }


        protected override AmcpPacket GetPacket()
        {
            Version serverVersion = null;

            if (DontCheckServerVersion == false)
                serverVersion = Connection.GetServerVersion();

            // CasparCG server versions before 2.1.0.3266 do not support unique packet id.
            var sendPacketId = serverVersion >= new Version(2, 1, 0, 3266);

            var amcpPacket = new AmcpPacket(GetCommandString())
            {
                SendPacketId = sendPacketId,
                CommandName = CommandName
            };

            return amcpPacket;
        }

        private string GetCommandString()
        {
            new CommandValidation().Validate(this);

            return new CommandStringBuilder().BuildString(this);
        }
    }
}