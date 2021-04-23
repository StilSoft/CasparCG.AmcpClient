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
using CasparCg.AmcpClient.Commands.Basic.Common;

namespace CasparCg.AmcpClient.Commands.Basic
{
    /// <summary>
    /// Enable/disable a logging category in the server.
    /// </summary>
    public class LogCategoryCommand : AbstractBaseCommand
    {
        // LOG CATEGORY
        // [category:calltrace,communication]
        // [enable:0,1]

        internal override string CommandName { get; } = "LOG CATEGORY";

        [Required]
        [EnumDataType(typeof(LogCategory))]
        [CommandParameter]
        public LogCategory? LogCategory { get; set; }

        [Required]
        [BooleanToString("1", "0")]
        [CommandParameter]
        public bool? EnableLogCategory { get; set; }


        public LogCategoryCommand(LogCategory? logCategory = null, bool? enableLogCategory = null)
        {
            LogCategory = logCategory;
            EnableLogCategory = enableLogCategory;
        }
    }
}