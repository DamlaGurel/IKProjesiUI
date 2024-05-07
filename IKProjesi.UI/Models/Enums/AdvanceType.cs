using System.ComponentModel.DataAnnotations;

namespace IKProjesi.UI.Models.Enums
{
    public enum AdvanceType
    {
        [Display(Name = "İlk Talep")]
        Talep1 =1,
        [Display(Name = "İkinci Talep")]
        Talep2,
        [Display(Name = "Üçüncü Talep")]
        Talep3
    }
}
