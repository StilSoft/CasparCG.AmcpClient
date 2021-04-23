//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using System;
using System.Globalization;
using CasparCg.AmcpClient.Common;
using CasparCg.AmcpClient.Utils;

namespace CasparCg.AmcpClient.Commands.Mixer.Common.Response
{
    public class MixerChromaGetCommandResponse : AmcpResponse
    {
        public bool IsChromaEnabled { get; private set; }
        public MixerChroma Chroma { get; private set; }


        internal override void ProcessData(AmcpParsedData data)
        {
            base.ProcessData(data);

            // TODO add logic to MixerChroma class Parse method ???
            var values = Converter.StringToDoubleArray(data.Data[1], " ", NumberStyles.AllowDecimalPoint, new CultureInfo("en-US"));

            IsChromaEnabled = Convert.ToBoolean(values[0]);
            Chroma = new MixerChroma(values[1], values[2], values[3], values[4], values[5], values[6], values[7], Convert.ToBoolean(values[8]));
        }
    }
}