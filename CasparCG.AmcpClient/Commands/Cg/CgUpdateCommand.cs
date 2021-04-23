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
using CasparCg.AmcpClient.Commands.Cg.Common.TemplateData;

namespace CasparCg.AmcpClient.Commands.Cg
{
    /// <summary>
    /// Update a template with new data.
    /// </summary>
    public class CgUpdateCommand : AbstractCgCommandWithSubCommandWithCgLayer
    {
        // CG
        // [video_channel:int]
        // {
        //     -[layer:int]
        //     |-9999
        // }
        // UPDATE
        // [cg_layer:int]
        // [data:string]

        internal override string SubCommandName { get; } = "UPDATE";

        [Required]
        [ValueToEscapedString]
        [CommandParameter("\"{0}\"")]
        public AbstractTemplateData TemplateData { get; set; }


        public CgUpdateCommand(int? channel = null, int? layer = null, int? cgLayer = null, AbstractTemplateData templateData = null)
        {
            Channel = channel;
            Layer = layer;
            CgLayer = cgLayer;
            TemplateData = templateData;
        }
    }
}