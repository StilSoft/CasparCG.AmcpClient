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
using StilSoft.CasparCG.AmcpClient.Commands.Cg.Common.TemplateData;
using System.ComponentModel.DataAnnotations;

namespace StilSoft.CasparCG.AmcpClient.Commands.Cg
{
    /// <summary>
    /// Prepare a template for displaying.
    /// </summary>
    public class CgAddCommand : AbstractCgCommand
    {
        // CG
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-9999
        // }
        // ADD 
        // [cg_layer:int]
        // [template:string]
        // [play-on-load:0,1]
        // {
        //     [data]
        // }

        internal override string CgCommandName { get; } = "ADD";

        [Required]
        [IsValidFullName]
        [WindowsToUnixPath]
        [ValueToEscapedString]
        [CommandParameter("\"{0}\"")]
        public string TemplateFullName { get; set; }

        /// <summary>
        /// Auto play cg on load.
        /// </summary>
        [Required]
        [BooleanToString("1", "0")]
        [CommandParameter]
        public bool? AutoPlay { get; set; }

        [ValueToEscapedString]
        [CommandParameter("\"{0}\"")]
        public AbstractTemplateData TemplateData { get; set; }


        public CgAddCommand(int? channel = null, int? layer = null, int? cgLayer = null,
                            string templateFullName = "", bool? autoPlay = null, AbstractTemplateData templateData = null)
        {
            Channel = channel;
            Layer = layer;
            CgLayer = cgLayer;
            TemplateFullName = templateFullName;
            AutoPlay = autoPlay;
            TemplateData = templateData;
        }
    }
}