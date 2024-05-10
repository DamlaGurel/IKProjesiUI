using IKProjesi.UI.Services.User;
using System.ComponentModel.DataAnnotations;

namespace IKProjesi.UI.Extensions.Validation
{
    public class PasswordValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var userService = validationContext.GetRequiredService<IUserApiService>();

            var password = value.ToString();

            //var model = (string)validationContext.ObjectInstance();

            //var userPassword = userService.

            return base.IsValid(value, validationContext);
        }
    }
}
