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
using CasparCg.AmcpClient.Utils;

namespace CasparCg.AmcpClient.CommandBuilder.Attributes.Validations
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class IsValidFileNameAttribute : ValidationAttribute
    {
        private readonly bool allowNullorEmptyStrings;


        public IsValidFileNameAttribute(bool allowNullorEmptyStrings = true)
        {
            this.allowNullorEmptyStrings = allowNullorEmptyStrings;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string errorMessage = $"Property '{validationContext.MemberName}' value is not valid file name.";

            if (string.IsNullOrEmpty(value?.ToString()))
            {
                return this.allowNullorEmptyStrings ? ValidationResult.Success : new ValidationResult(errorMessage);
            }

            if (!(value is string))
            {
                throw new InvalidOperationException(
                    $"'{nameof(IsValidFileNameAttribute)}' attribute can be used only on 'string' value type properties.");
            }

            return PathUtils.IsValidFileName(value.ToString()) ? ValidationResult.Success : new ValidationResult(errorMessage);
        }
    }
}