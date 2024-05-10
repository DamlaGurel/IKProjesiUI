using System.ComponentModel.DataAnnotations;

namespace IKProjesi.UI.Extensions.Validation
{
    public class ContractDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var endContractDateProperty = validationContext.ObjectType.GetProperty("EndContractDate");

            var endContractDateValue = (DateTime?)endContractDateProperty.GetValue(validationContext.ObjectInstance, null);

            var startContractDateValue = (DateTime?)value;

            if (endContractDateValue.HasValue && startContractDateValue.HasValue)
            {
                if (startContractDateValue > endContractDateValue)
                {
                    return new ValidationResult("Sözleşme başlangıç tarihi bitiş tarihinden sonra olamaz");
                }
            }
            return ValidationResult.Success;
        }
    }
}
