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

namespace CasparCg.AmcpClient.Utils
{
    public static class Converter
    {
        public static double[] StringToDoubleArray(string data, string delimiter, NumberStyles numberStyles, CultureInfo cutureInfo)
        {
            var values = data.Split(delimiter.ToCharArray());

            return Array.ConvertAll(values, s => double.Parse(s, numberStyles, cutureInfo));
        }
    }
}