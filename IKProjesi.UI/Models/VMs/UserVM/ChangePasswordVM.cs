using System.ComponentModel.DataAnnotations;

namespace IKProjesi.UI.Models.VMs.UserVM
{
    public class ChangePasswordVM
    {
        [Required(ErrorMessage = "Geçiçi şifre alanı boş bırakılamaz.")]
        public string TemporaryPassword { get; set; }

        [Required(ErrorMessage = "Yeni şifre alanı boş bırakılamaz.")]
        [DataType(DataType.Password, ErrorMessage = "Şifreniz gerekli kriterleri sağlamıyor.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Şifre tekrarı girilmesi zorunludur.")]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword), ErrorMessage = "Şifreler birbirlerine eşit olmalıdır.")]
        public string ConfirmPassword { get; set; }
    }
}
