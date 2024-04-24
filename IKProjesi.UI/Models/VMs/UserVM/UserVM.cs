using System.ComponentModel.DataAnnotations;

namespace IKProjesi.UI.Models.VMs.UserVM
{
    public class UserVM
    {
        [Required(ErrorMessage = "E-Posta adresinizi giriniz.")]
        [Display(Name = "E-Posta")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifrenizi giriniz.")]
        [Display(Name = "Kullanıcı Şifresi")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
