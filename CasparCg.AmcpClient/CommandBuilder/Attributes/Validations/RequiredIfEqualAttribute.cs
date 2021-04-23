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
using System.Reflection;

namespace CasparCg.AmcpClient.CommandBuilder.Attributes.Validations
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class RequiredIfEqualAttribute : RequiredAttribute
    {
        private readonly string propertyName;
        private readonly object value;


        public RequiredIfEqualAttribute(string propertyName, object value)
        {
            this.propertyName = propertyName;
            this.value = value;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (base.IsValid(value))
            {
                return ValidationResult.Success;
            }

            PropertyInfo property = validationContext.ObjectType.GetProperty(this.propertyName);

            if (property == null)
            {
                throw new InvalidOperationException(
                    $"Property '{this.propertyName}' requested by '{nameof(RequiredIfEqualAttribute)}' attribute on '{validationContext.MemberName}' property not found.");
            }

            if (validationContext.MemberName.Equals(this.propertyName))
            {
                throw new InvalidOperationException(
                    $"Cannot use '{nameof(RequiredIfEqualAttribute)}' attribute on '{validationContext.MemberName}' property to check property it self.");
            }

            object propertyValue = property.GetValue(validationContext.ObjectInstance);

            return Equals(propertyValue, this.value) ? new ValidationResult(this.ErrorMessage) : ValidationResult.Success;
        }
    }
}