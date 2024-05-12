using System.ComponentModel.DataAnnotations;

namespace IKProjesi.UI.Models.VMs.UserVM
{
    public class SendPasswordVM
    {
        [Required(ErrorMessage = "E-Posta adresinizi giriniz.")]
        [Display(Name = "Kisisel E-Posta")]
        public string KisiselMail { get; set; }

    }
}
