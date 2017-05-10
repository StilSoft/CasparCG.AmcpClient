//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using StilSoft.CasparCG.AmcpClient.Common;

namespace StilSoft.CasparCG.AmcpClient.Commands.Data.Common.Reponse
{
    public class DataRetrieveCommandResponse : AmcpResponse
    {
        public string DataValue { get; private set; }


        internal override void ProcessData(AmcpParsedData data)
        {
            base.ProcessData(data);

            DataValue = data.Data[1];
        }
    }
}