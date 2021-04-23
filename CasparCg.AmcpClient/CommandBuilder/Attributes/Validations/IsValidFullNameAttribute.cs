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
using CasparCg.AmcpClient.Common;

namespace CasparCg.AmcpClient.CommandBuilder.Attributes.Validations
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class IsValidFullNameAttribute : ValidationAttribute
    {
        private readonly bool allowNullorEmptyStrings;


        public IsValidFullNameAttribute(bool allowNullorEmptyStrings = true)
        {
            this.allowNullorEmptyStrings = allowNullorEmptyStrings;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string errorMessage = $"Property '{validationContext.MemberName}' value is not valid full name.";

            if (string.IsNullOrEmpty(value?.ToString()))
            {
                return this.allowNullorEmptyStrings ? ValidationResult.Success : new ValidationResult(errorMessage);
            }

            if (!(value is string))
            {
                throw new InvalidOperationException(
                    $"'{nameof(IsValidPathAttribute)}' attribute can be used only on 'string' value type properties.");
            }

            try
            {
                if (!string.IsNullOrWhiteSpace(value.ToString()))
                {
                    var dummy = new CasparFileInfo(value.ToString());
                }
            }
            catch
            {
                return new ValidationResult(errorMessage);
            }

            return ValidationResult.Success;
        }
    }
}