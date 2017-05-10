//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using StilSoft.CasparCG.AmcpClient.Commands.Query.Common.Info;
using StilSoft.CasparCG.AmcpClient.Common;
using StilSoft.CasparCG.AmcpClient.Utils;

namespace StilSoft.CasparCG.AmcpClient.Commands.Query.Common.Response
{
    public class GlInfoCommandResponse : AmcpResponse
    {
        public string GlInfoXml { get; private set; }
        public GlInfo GlInfo { get; private set; }


        internal override void ProcessData(AmcpParsedData data)
        {
            base.ProcessData(data);

            GlInfoXml = data.Data[1];
            GlInfo = Serializer.XmlDeserialize<GlInfo>(data.Data[1]);
        }
    }
}