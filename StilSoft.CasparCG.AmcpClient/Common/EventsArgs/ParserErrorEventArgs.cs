﻿//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using System;

namespace StilSoft.CasparCG.AmcpClient.Common.EventsArgs
{
    public class ParserErrorEventArgs : EventArgs
    {
        public Exception Exception { get; }


        public ParserErrorEventArgs(Exception exception)
        {
            Exception = exception;
        }
    }
}