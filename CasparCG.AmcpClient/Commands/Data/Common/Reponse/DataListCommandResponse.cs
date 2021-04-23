//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using System.Collections.Generic;
using CasparCg.AmcpClient.Common;

namespace CasparCg.AmcpClient.Commands.Data.Common.Reponse
{
    public class DataListCommandResponse : AmcpResponse
    {
        private readonly List<DataFileInfo> _dataList = new List<DataFileInfo>();


        internal override void ProcessData(AmcpParsedData data)
        {
            base.ProcessData(data);

            for (var i = 1; i < data.Data.Count; i++)
                _dataList.Add(new DataFileInfo(data.Data[i]));
        }

        public IReadOnlyList<DataFileInfo> GetDataList()
        {
            return _dataList;
        }
    }
}