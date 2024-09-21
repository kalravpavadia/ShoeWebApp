using System.ComponentModel.DataAnnotations;
namespace ShoeWebApp.attributes

{
    public class CustomValidationAttributes : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return base.IsValid(value);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }
    }
}
