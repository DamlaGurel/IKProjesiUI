using System.ComponentModel.DataAnnotations;

namespace IKProjesi.UI.Extensions
{
    public class CompanyDateTimeValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {

            var startContractDateProperty = validationContext.ObjectType.GetProperty("StartContractDate");

            var startContractDateValue = (DateTime?)startContractDateProperty.GetValue(validationContext.ObjectInstance, null);

            var endContractDateProperty = validationContext.ObjectType.GetProperty("EndContractDate");

            var endContractDateValue = (DateTime?)endContractDateProperty.GetValue(validationContext.ObjectInstance, null);

            var foundationYearValue = (DateTime?)value;

            if (foundationYearValue.HasValue && startContractDateValue.HasValue && endContractDateValue.HasValue)
            {
                if (foundationYearValue > startContractDateValue || foundationYearValue > endContractDateValue)
                {
                    return new ValidationResult("Kuruluş yılı, sözleşme başlangıç ya da bitiş tarihinden sonra olamaz.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
