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

namespace CasparCg.AmcpClient.Common.EventsArgs
{
    public class DataReceivedEventArgs : EventArgs
    {
        public byte[] Data { get; }


        public DataReceivedEventArgs(byte[] data)
        {
            Data = data;
        }
    }
}