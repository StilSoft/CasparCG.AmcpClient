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
using CasparCg.AmcpClient.Common;

namespace CasparCg.AmcpClient.Commands.Mixer.Common.Response
{
    public class MixerBlendGetCommandResponse : AmcpResponse
    {
        public BlendMode BlendMode { get; private set; }


        internal override void ProcessData(AmcpParsedData data)
        {
            base.ProcessData(data);

            BlendMode = (BlendMode)Enum.Parse(typeof(BlendMode), data.Data[1].Replace("_", ""), true);
        }
    }
}