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

namespace CasparCg.AmcpClient.CommandBuilder.Attributes.Conditions
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    internal abstract class AbstractPropertyValueConditionAttribute : Attribute
    {
        public string PropertyName { get; }
        public object Value { get; }


        protected AbstractPropertyValueConditionAttribute(string propertyName, object value)
        {
            PropertyName = propertyName;
            Value = value;
        }

        public abstract bool IsTrue(object value);
    }
}