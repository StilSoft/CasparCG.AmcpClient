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
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using CasparCg.AmcpClient.CommandBuilder.Attributes;

namespace CasparCg.AmcpClient.CommandBuilder
{
    internal class CommandValidation
    {
        public bool Validate(object obj, bool throwException = true)
        {
            if (obj.GetType().GetCustomAttribute<CommandBuilderObjectAttribute>() == null)
                throw new InvalidOperationException($"Cannot validate '{obj.GetType().Name}' object without '{nameof(CommandBuilderObjectAttribute)}' attribute.");

            return ValidateRecursive(obj, throwException, 0);
        }

        private bool ValidateRecursive(object obj, bool throwException, int deepLevel)
        {
            const int maxDeepLevel = 100;

            // Prevent "StackOverflowException" (this should never happen)
            if (++deepLevel == maxDeepLevel)
                throw new InvalidOperationException("Recursive function call exceeded the permitted deep level.");

            // Validate all properties with "CommandParameterAttribute"
            foreach (var property in CommandParameterAttribute.GetOrderedProperties(obj))
            {
                // If property is value type and is not nullable, than must be set to nullable
                if (property.PropertyType.IsValueType && Nullable.GetUnderlyingType(property.PropertyType) == null)
                {
                    if (throwException)
                        throw new InvalidOperationException($"'{property.Name}' property must be nullable.");

                    return false;
                }
            }

            // Validate all properties with attributes derived from "ValidationAttribute"
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);

            if (results.Count > 0)
            {
                if (throwException)
                    throw new ArgumentException(results[0].ToString());

                return false;
            }


            // Find all properties value with 'CommandBuilderObjectAttribute' and validate it recursively
            var properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(obj);

                if (propertyValue == null)
                    continue;

                if (propertyValue.GetType().GetCustomAttribute<CommandBuilderObjectAttribute>() != null)
                    ValidateRecursive(propertyValue, throwException, deepLevel);
            }

            return true;
        }
    }
}