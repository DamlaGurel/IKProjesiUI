using System.ComponentModel.DataAnnotations;

namespace IKProjesi.UI.Extensions
{
    public class BirthDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var startDateProperty = validationContext.ObjectType.GetProperty("StartDateOfWork");
            var startDateValue = (DateTime?)startDateProperty.GetValue(validationContext.ObjectInstance, null);

            var birthDateValue = (DateTime?)value;

            if (birthDateValue.HasValue && startDateValue.HasValue)
            {
                if (birthDateValue > startDateValue)
                {
                    return new ValidationResult("Doğum tarihi işe başlama tarihinden büyük olamaz.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
