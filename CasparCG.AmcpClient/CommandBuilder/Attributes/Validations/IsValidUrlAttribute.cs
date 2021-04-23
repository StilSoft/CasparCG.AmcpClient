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
    internal class IsValidUrlAttribute : ValidationAttribute
    {
        private readonly bool _allowNullorEmptyStrings;


        public IsValidUrlAttribute(bool allowNullorEmptyStrings = true)
        {
            _allowNullorEmptyStrings = allowNullorEmptyStrings;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var errorMessage = $"Property '{validationContext.MemberName}' value is not valid url.";

            if (string.IsNullOrEmpty(value?.ToString()))
                return _allowNullorEmptyStrings ? ValidationResult.Success : new ValidationResult(errorMessage);

            if (!(value is string))
                throw new InvalidOperationException($"'{nameof(IsValidPathAttribute)}' attribute can be used only on 'string' value type properties.");

            return Uri.IsWellFormedUriString(value.ToString(), UriKind.Absolute) ? ValidationResult.Success : new ValidationResult(errorMessage);
        }
    }
}