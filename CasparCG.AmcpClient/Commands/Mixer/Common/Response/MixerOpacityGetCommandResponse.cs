//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using System.Globalization;
using CasparCg.AmcpClient.Common;

namespace CasparCg.AmcpClient.Commands.Mixer.Common.Response
{
    public class MixerOpacityGetCommandResponse : AmcpResponse
    {
        public double Opacity { get; private set; }


        internal override void ProcessData(AmcpParsedData data)
        {
            base.ProcessData(data);

            Opacity = double.Parse(data.Data[1], NumberStyles.AllowDecimalPoint, new CultureInfo("en-US"));
        }
    }
}