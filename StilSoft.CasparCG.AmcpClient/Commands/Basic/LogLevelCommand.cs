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
using StilSoft.CasparCG.AmcpClient.Commands.Basic.Common;
using System.ComponentModel.DataAnnotations;

namespace StilSoft.CasparCG.AmcpClient.Commands.Basic
{
    /// <summary>
    /// Change the log level of the server.
    /// </summary>
    public class LogLevelCommand : AbstractBaseCommand
    {
        // LOG LEVEL
        // [level:trace,debug,info,warning,error,fatal]

        internal override string CommandName { get; } = "LOG LEVEL";

        [Required]
        [EnumDataType(typeof(LogLevel))]
        [CommandParameter]
        public LogLevel? LogLevel { get; set; }


        public LogLevelCommand(LogLevel? logLevel = null)
        {
            LogLevel = logLevel;
        }
    }
}