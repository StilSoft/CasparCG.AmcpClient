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
    internal abstract class AbstractPropertyIncludedConditionAttribute : Attribute
    {
        public string PropertyName { get; }


        protected AbstractPropertyIncludedConditionAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}