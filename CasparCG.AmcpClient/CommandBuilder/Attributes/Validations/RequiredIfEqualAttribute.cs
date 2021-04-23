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
using System.ComponentModel.DataAnnotations;

namespace CasparCg.AmcpClient.CommandBuilder.Attributes.Validations
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class RequiredIfEqualAttribute : RequiredAttribute
    {
        private readonly string _propertyName;
        private readonly object _value;


        public RequiredIfEqualAttribute(string propertyName, object value)
        {
            _propertyName = propertyName;
            _value = value;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (base.IsValid(value))
                return ValidationResult.Success;

            var property = validationContext.ObjectType.GetProperty(_propertyName);

            if (property == null)
                throw new InvalidOperationException($"Property '{_propertyName}' requested by '{nameof(RequiredIfEqualAttribute)}' attribute on '{validationContext.MemberName}' property not found.");

            if (validationContext.MemberName.Equals(_propertyName))
                throw new InvalidOperationException($"Cannot use '{nameof(RequiredIfEqualAttribute)}' attribute on '{validationContext.MemberName}' property to check property it self.");

            var propertyValue = property.GetValue(validationContext.ObjectInstance);

            return Equals(propertyValue, _value) ? new ValidationResult(ErrorMessage) : ValidationResult.Success;
        }
    }
}