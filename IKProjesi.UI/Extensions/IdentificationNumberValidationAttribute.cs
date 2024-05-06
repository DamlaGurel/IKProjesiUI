using System.ComponentModel.DataAnnotations;

namespace IKProjesi.UI.Extensions
{
    public class IdentificationNumberValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int toplam = 0, ciftToplam = 0, tekToplam = 0;
            if (value == null)
                return new ValidationResult("TC boş olamaz");

            string id = value.ToString();
            if (id.Length != 11 || id[0] == '0')
                return new ValidationResult("TC 11 haneden küçük olamaz ve 0 ile başlayamaz");

            for (int i = 0; i <= 9; i++)
            {
                toplam += Convert.ToInt32(id[i].ToString());

                if (i % 2 == 0)
                    tekToplam += Convert.ToInt32(id[i].ToString());
                else if (i % 2 != 0 && i <= 7)
                    ciftToplam += Convert.ToInt32(id[i].ToString());
            }

            if ((7 * tekToplam - ciftToplam) % 10 != Convert.ToInt32(id[9].ToString()))

                return new ValidationResult("Tc ile ilgili bir özellik uyumlu değil.");


            if (toplam % 10 != Convert.ToInt32(id[10].ToString()))
                return new ValidationResult("Tc ile ilgili diğer bir özellik uyumlu değil.");

            return ValidationResult.Success;
        }
    }

}
