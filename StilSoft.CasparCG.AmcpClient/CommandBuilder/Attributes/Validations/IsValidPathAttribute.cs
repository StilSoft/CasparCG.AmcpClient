//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using StilSoft.CasparCG.AmcpClient.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace StilSoft.CasparCG.AmcpClient.CommandBuilder.Attributes.Validations
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class IsValidPathAttribute : ValidationAttribute
    {
        private readonly bool _isNullValid;


        public IsValidPathAttribute(bool isNullValid = true)
        {
            _isNullValid = isNullValid;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var errorMessage = $"Property \'{validationContext.MemberName}\' value is not valid path.";

            if (value == null)
                return _isNullValid ? ValidationResult.Success : new ValidationResult(errorMessage);

            if (!(value is string))
               throw new InvalidOperationException($"\'{nameof(IsValidPathAttribute)}\' attribute can be used only on 'string' value type properties.");

            return PathUtils.IsValidPath(value.ToString()) ? ValidationResult.Success : new ValidationResult(errorMessage);
        }
    }
}