using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace IKProjesi.UI.Extensions.Validation
{
    public class TotalAdvanceValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var paymentProperty = validationContext.ObjectType.GetProperty("Payment");
            var paymentValue = (double?)paymentProperty.GetValue(validationContext.ObjectInstance);
            var totalAdvanceValue = (double?)value;

            if (paymentValue != null && totalAdvanceValue != null && totalAdvanceValue > paymentValue * 3)
            {
                return new ValidationResult("Toplam avans miktarı, maaşın 3 katından fazla olamaz.");
            }

            return ValidationResult.Success;

        }
    }
}
