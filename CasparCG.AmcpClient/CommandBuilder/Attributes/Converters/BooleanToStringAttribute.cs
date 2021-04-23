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
    internal class BooleanToStringAttribute : AbstractValueToStringConverterAttribute
    {
        public string TrueValue { get; set; }
        public string FalseValue { get; set; }


        public BooleanToStringAttribute(string trueValue, string falseValue)
        {
            TrueValue = trueValue;
            FalseValue = falseValue;
        }

        public override string GetValue(object value)
        {
            if (!(value is bool))
                throw new InvalidOperationException($"'{nameof(BooleanToStringAttribute)}' attribute can be used only on 'bool' value type properties.");

            return (bool)value ? TrueValue : FalseValue;
        }
    }
}