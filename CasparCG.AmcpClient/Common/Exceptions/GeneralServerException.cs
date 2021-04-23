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

namespace CasparCg.AmcpClient.Common.Exceptions
{
    public class GeneralServerException : Exception
    {
        public GeneralServerException()
        {
        }

        public GeneralServerException(string message) : base(message)
        {
        }

        public GeneralServerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}