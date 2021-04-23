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
using CasparCg.AmcpClient.Common.EventsArgs;

namespace CasparCg.AmcpClient.Abstracts.Command
{
    public interface ICommandConnection
    {
        void Send(byte[] data);
        event EventHandler<DataReceivedEventArgs> DataReceived;
        Version GetServerVersion();
    }
}