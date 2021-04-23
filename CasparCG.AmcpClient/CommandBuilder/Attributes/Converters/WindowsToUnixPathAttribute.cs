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
using CasparCg.AmcpClient.Utils;

namespace CasparCg.AmcpClient.CommandBuilder.Attributes.Converters
{
    internal class WindowsToUnixPathAttribute : AbstractValueToStringConverterAttribute
    {
        public override string GetValue(object value)
        {
            if (!(value is string))
                throw new InvalidOperationException($"'{nameof(WindowsToUnixPathAttribute)}' attribute can be used only on 'string' value type properties.");

            return PathUtils.WindowsToUnixPath(value.ToString());
        }
    }
}