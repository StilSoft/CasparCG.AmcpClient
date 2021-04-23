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
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CasparCg.AmcpClient.CommandBuilder.Attributes;
using CasparCg.AmcpClient.CommandBuilder.Attributes.Conditions;
using CasparCg.AmcpClient.CommandBuilder.Attributes.Converters;

namespace CasparCg.AmcpClient.CommandBuilder
{
    internal class CommandStringBuilder
    {
        private HashSet<Tuple<string, string, string>> _checkedProperty;


        public string BuildString(object obj)
        {
            if (obj.GetType().GetCustomAttribute<CommandBuilderObjectAttribute>() == null)
                throw new InvalidOperationException($"Cannot build string on '{obj.GetType().Name}' object without '{nameof(CommandBuilderObjectAttribute)}' attribute.");

            return BuildStringRecursive(obj, 0);
        }

        private string BuildStringRecursive(object obj, int deepLevel)
        {
            const int maxDeepLevel = 100;

            // Prevent "StackOverflowException" (this should never happen)
            if (++deepLevel == maxDeepLevel)
                throw new InvalidOperationException("Recursive function call exceeded the permitted deep level.");


            var finalString = new StringBuilder();

            // Loop through all properties with "CommandParameterAttribute" attribute
            foreach (var property in CommandParameterAttribute.GetOrderedProperties(obj))
            {
                // Get property value
                var propertyValue = property.GetValue(obj);

                if (propertyValue == null)
                    continue;

                // Check if property value can be included in final command string
                if (!CanIncludeProperty(obj, property))
                    continue;

                // if property value has 'CommandBuilderObjectAttribute' then build string from it recursively
                if (propertyValue.GetType().GetCustomAttribute<CommandBuilderObjectAttribute>() != null)
                {
                    var value = BuildStringRecursive(propertyValue, deepLevel);

                    if (!string.IsNullOrWhiteSpace(value))
                        finalString.Append($" {value}");

                    continue;
                }


                // Get "CommandParameterAttribute" from property
                var commandParameterAttribute = property.GetCustomAttribute<CommandParameterAttribute>();

                if (!commandParameterAttribute.RemoveWhiteSpaceBeforeValue)
                    finalString.Append(" ");

                var convertedPropertyValue = GetConvertedPropertyValue(obj, property);

                // If value format is set in "CommandParameterAttribute", then use it to format property value
                if (!string.IsNullOrWhiteSpace(commandParameterAttribute.Format))
                    finalString.Append(string.Format(commandParameterAttribute.Format, convertedPropertyValue));
                else
                    finalString.Append($"{convertedPropertyValue}");
            }

            return finalString.ToString().Trim();
        }

        private string GetConvertedPropertyValue(object obj, PropertyInfo property)
        {
            // Get property value
            var propertyValue = property.GetValue(obj);

            if (propertyValue == null)
                return "";

            var propertyValueString = propertyValue.ToString();

            var isAlreadyConverted = false;

            // If "AbstractValueToStringConverterAttribute" attribute is set, then use it to convert property value.
            foreach (var converter in property.GetCustomAttributes<AbstractValueToStringConverterAttribute>())
            {
                propertyValueString = converter.GetValue(!isAlreadyConverted ? propertyValue : propertyValueString);

                isAlreadyConverted = true;
            }

            return propertyValueString;
        }

        private bool CanIncludeProperty(object obj, PropertyInfo propertyInfo)
        {
            _checkedProperty = new HashSet<Tuple<string, string, string>>();

            return CanIncludePropertyRecursive(obj, propertyInfo, 0);
        }

        private bool CanIncludePropertyRecursive(object obj, PropertyInfo propertyInfo, int deepLevel)
        {
            const int maxDeepLevel = 100;

            // Prevent "StackOverflowException" (this should never happen)
            if (++deepLevel == maxDeepLevel)
                throw new InvalidOperationException("Recursive function call exceeded the permitted deep level.");

            // If converted property value is null or empty string, then ignore it
            if (string.IsNullOrWhiteSpace(GetConvertedPropertyValue(obj, propertyInfo)))
                return false;


            foreach (var propertyAttribute in propertyInfo.GetCustomAttributes<AbstractPropertyIncludedConditionAttribute>())
            {
                // Track checked property-attributes and ignore it if already checked, to prevent recursive dead loop
                if (!_checkedProperty.Add(new Tuple<string, string, string>(propertyInfo.Name, propertyAttribute.GetType().Name, propertyAttribute.PropertyName)))
                    continue;

                var property = obj.GetType().GetProperty(propertyAttribute.PropertyName);

                if (property == null)
                    throw new InvalidOperationException($"Property '{propertyAttribute.PropertyName}' requested by '{propertyAttribute.GetType().Name}' attribute on '{propertyInfo.Name}' property not found.");

                if (property.Name.Equals(propertyInfo.Name))
                    throw new InvalidOperationException($"Cannot use '{propertyAttribute.GetType().Name}' attribute on '{propertyInfo.Name}' property to check property it self.");

                var canIncludeProperty = CanIncludePropertyRecursive(obj, property, deepLevel);

                if (propertyAttribute is IncludeIfIncludedAttribute && !canIncludeProperty ||
                    propertyAttribute is IncludeIfNotIncludedAttribute && canIncludeProperty)
                    return false;
            }


            var hasValueConditionAttribute = false;
            var wasTrue = false;

            foreach (var propertyAttribute in propertyInfo.GetCustomAttributes<AbstractPropertyValueConditionAttribute>())
            {
                hasValueConditionAttribute = true;

                var property = obj.GetType().GetProperty(propertyAttribute.PropertyName);

                if (property == null)
                    throw new InvalidOperationException($"Property '{propertyAttribute.PropertyName}' requested by '{propertyAttribute.GetType().Name}' attribute on '{propertyInfo.Name}' property not found.");

                // Get property value and check it
                if (propertyAttribute.IsTrue(property.GetValue(obj)))
                {
                    wasTrue = true;
                }
                else
                {
                    // If is not true and if is not derived from "AbstractPropertyValueOrConditionAttribute" (|| operator attribute), then return false
                    if (!(propertyAttribute is AbstractPropertyValueOrConditionAttribute))
                        return false;
                }
            }

            if (hasValueConditionAttribute && !wasTrue)
                return false;


            return true;
        }
    }
}