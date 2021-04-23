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
using System.ComponentModel;
using System.Reflection;

namespace CasparCg.AmcpClient.CommandBuilder.Attributes.Converters
{
    /// <summary>
    /// Convert enum to string (Gets value from <seealso cref="DescriptionAttribute"/> if is set on Enum).
    /// </summary>
    internal class EnumToStringAttribute : AbstractValueToStringConverterAttribute
    {
        public override string GetValue(object value)
        {
            if (!(value is Enum))
                throw new InvalidOperationException($"'{nameof(EnumToStringAttribute)}' attribute can be used only on 'Enum' type properties.");

            var fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo == null)
                throw new ArgumentException($"'{nameof(EnumToStringAttribute)}' attribute can not found value '{value}' in enum '{value.GetType().Name}'.");

            // Get "DescriptionAttribute" attribute from Enum and return Description value
            var descriptionAttribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>();

            if (descriptionAttribute == null)
                return value.ToString();
                //throw new InvalidOperationException ($"'{nameof(EnumToStringAttribute)}' attribute can not found '{nameof(DescriptionAttribute)}' attribute on enum '{value.GetType().Name}' value '{value}'.");

            return descriptionAttribute.Description;
        }
    }
}