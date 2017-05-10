using StilSoft.CasparCG.AmcpClient.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace StilSoft.CasparCG.AmcpClient.CommandBuilder.Attributes.Validations
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class IsValidFullNameAttribute : ValidationAttribute
    {
        private readonly bool _isNullValid;


        public IsValidFullNameAttribute(bool isNullValid = true)
        {
            _isNullValid = isNullValid;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var errorMessage = $"Property \'{validationContext.MemberName}\' value is not valid full name.";

            if (value == null)
                return _isNullValid ? ValidationResult.Success : new ValidationResult(errorMessage);

            if (!(value is string))
                throw new InvalidOperationException($"\'{nameof(IsValidPathAttribute)}\' attribute can be used only on 'string' value type properties.");

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