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

namespace StilSoft.Network.EventsArgs
{
    public class ConnectionStateChangedEventArgs : EventArgs
    {
        public ConnectionState State { get; }


        public ConnectionStateChangedEventArgs(ConnectionState state)
        {
            State = state;
        }
    }
}