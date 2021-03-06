﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Moe.Lib.Web
{
    /// <summary>
    ///     Class AvailableValuesAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class EnumAvailableValuesAttribute : ValidationAttribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AvailableValuesAttribute" /> class.
        /// </summary>
        public EnumAvailableValuesAttribute()
            : base(@"The {0} value is not available.")
        {
        }

        /// <summary>
        ///     Applies formatting to an error message, based on the data field where the error occurred.
        /// </summary>
        /// <returns>
        ///     An instance of the formatted error message.
        /// </returns>
        /// <param name="name">The name to include in the formatted message.</param>
        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, this.ErrorMessageString, name);
        }

        /// <summary>
        ///     Validates the specified value with respect to the current validation attribute.
        /// </summary>
        /// <returns>
        ///     An instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult" /> class.
        /// </returns>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo validatingProperty = validationContext.ObjectType.GetProperty(validationContext.MemberName);
            if (validatingProperty.PropertyType.IsEnum)
            {
                Array availableValues = validatingProperty.PropertyType.GetEnumValues();
                if (availableValues.Cast<object>().Any(availableValue => Convert.ToInt32(availableValue) == Convert.ToInt32(value)))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
        }
    }
}