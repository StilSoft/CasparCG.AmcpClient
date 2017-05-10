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
using StilSoft.CasparCG.AmcpClient.CommandBuilder.Attributes.Validations;
using StilSoft.CasparCG.AmcpClient.Commands.Query.Common.Response;
using System.ComponentModel.DataAnnotations;

namespace StilSoft.CasparCG.AmcpClient.Commands.Query
{
    /// <summary>
    /// Get information about a media file.
    /// </summary>
    /// <remarks>
    /// Returns information about a media file.
    /// If a file with the same name exist in multiple directories, all of them are returned.
    /// </remarks>
    public class CinfCommand : AbstractBaseCommand<CinfCommandResponse>
    {
        // CINF
        // [filename:string]

        internal override string CommandName { get; } = "CINF";

        [Required]
        [IsValidFileName]
        [ValueToEscapedString]
        [CommandParameter("\"{0}\"")]
        public string MediaFileName { get; set; }   // TODO caspar accept only filename not fullname ???


        public CinfCommand(string mediaFileName = "")
        {
            MediaFileName = mediaFileName;
        }
    }
}