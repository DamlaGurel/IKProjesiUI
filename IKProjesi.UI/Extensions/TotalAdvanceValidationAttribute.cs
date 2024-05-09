using System.ComponentModel.DataAnnotations;

namespace IKProjesi.UI.Extensions
{
    public class TotalAdvanceValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var paymentProperty = validationContext.ObjectType.GetProperty("Payment");
            var paymentValue = (double?)paymentProperty.GetValue(validationContext.ObjectInstance);

            //var totalAdvancePayment



            return base.IsValid(value, validationContext);
        }
    }
}
