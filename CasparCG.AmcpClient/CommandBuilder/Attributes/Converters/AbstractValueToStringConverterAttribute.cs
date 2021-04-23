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

namespace CasparCg.AmcpClient.CommandBuilder.Attributes.Converters
{
    [AttributeUsage(AttributeTargets.Property)]
    internal abstract class AbstractValueToStringConverterAttribute : Attribute
    {
        public abstract string GetValue(object value);
    }
}