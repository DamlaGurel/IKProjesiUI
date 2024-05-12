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

            if (password.Length < 3 || password.Length > 20)
            {
                return new ValidationResult("Şifreniz en az 3, en çok 20 karakterden oluşmalıdır.");
            }
            if (!password.Any(char.IsDigit) || !password.Any(char.IsUpper) || !password.Any(char.IsLower))
            {
                return new ValidationResult("Şifreniz en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.");
            }
            if (password.All(char.IsLetterOrDigit))
            {
                return new ValidationResult("Şifreniz en az bir özel karakter içermelidir.");
            }

            return ValidationResult.Success;
        }
    }
}
