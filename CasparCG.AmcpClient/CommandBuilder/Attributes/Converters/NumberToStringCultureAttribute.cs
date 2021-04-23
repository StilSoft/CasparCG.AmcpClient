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

namespace CasparCg.AmcpClient.CommandBuilder.Attributes.Converters
{
    /// <summary>
    /// Converts number to string using specified culture
    /// </summary>
    internal class NumberToStringCultureAttribute : AbstractValueToStringConverterAttribute
    {
        private readonly CultureInfo _culture;

        public NumberToStringCultureAttribute(string cultureName)
        {
            _culture = new CultureInfo(cultureName);
        }

        public override string GetValue(object value)
        {
            if (!IsNumber(value))
                throw new InvalidOperationException($"'{nameof(NumberToStringCultureAttribute)}' attribute can be used only on 'numeric' value type properties.");

            return double.Parse(value.ToString()).ToString(_culture);
        }

        private bool IsNumber(object value)
        {
            return value is sbyte ||
                   value is byte ||
                   value is short ||
                   value is ushort ||
                   value is int ||
                   value is uint ||
                   value is long ||
                   value is ulong ||
                   value is float ||
                   value is double ||
                   value is decimal;
        }
    }
}