//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using CasparCg.AmcpClient.Commands.Query.Common.Info;
using CasparCg.AmcpClient.Common;
using CasparCg.AmcpClient.Utils;

namespace CasparCg.AmcpClient.Commands.Query.Common.Response
{
    public class InfoPathsCommandResponse : AmcpResponse
    {
        public string PathsInfoXml { get; private set; }
        public PathsInfo PathsInfo { get; private set; }


        internal override void ProcessData(AmcpParsedData data)
        {
            base.ProcessData(data);

            PathsInfoXml = data.Data[1];
            PathsInfo = Serializer.XmlDeserialize<PathsInfo>(data.Data[1]);
        }
    }
}