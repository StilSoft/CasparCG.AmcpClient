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
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CasparCg.AmcpClient.CommandBuilder.Attributes
{
    /// <summary>
    /// Specifies that a property value should be included in command string.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    internal class CommandParameterAttribute : Attribute
    {
        private int Order { get; }

        public string Format { get; }
        public bool RemoveWhiteSpaceBeforeValue { get; }
        

        public CommandParameterAttribute([CallerLineNumber]int order = 0)
        {
            Order = order;
        }

        public CommandParameterAttribute(string format, bool removeWhiteSpaceBeforeValue = false, [CallerLineNumber]int order = 0)
        {
            Format = format;
            RemoveWhiteSpaceBeforeValue = removeWhiteSpaceBeforeValue;
            Order = order;
        }

        public static IEnumerable<PropertyInfo> GetOrderedProperties(object obj)
        {
            var orderedProperies = new SortedDictionary<int, PropertyInfo>();

            var properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var propertyAttribute = property.GetCustomAttribute<CommandParameterAttribute>();

                if (propertyAttribute != null)
                    orderedProperies.Add(propertyAttribute.Order, property);
            }

            return orderedProperies.Values.ToList();
        }
    }
}