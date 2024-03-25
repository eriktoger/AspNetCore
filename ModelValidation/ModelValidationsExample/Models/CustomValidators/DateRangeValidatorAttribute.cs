using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidationsExample.CustomValidators
{
    public class DateRangeValidatorAttribute : ValidationAttribute
    {
        public string OtherPropertyName { get; set; } = "from_date";

        public DateRangeValidatorAttribute()
        {

        }
        public DateRangeValidatorAttribute(string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);
                if (otherProperty == null)
                {
                    return new ValidationResult($"{OtherPropertyName} do not exits");
                }

                DateTime otherTime = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));

                DateTime date = Convert.ToDateTime(value);
                if (date > otherTime)
                {
                    return new ValidationResult($"{date} needs to be newer than {otherTime}");
                }
            }
            return ValidationResult.Success;
        }

    }
}