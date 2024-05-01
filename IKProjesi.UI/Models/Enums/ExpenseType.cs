using System.ComponentModel.DataAnnotations;

namespace IKProjesi.UI.Models.Enums
{
    public enum ExpenseType
    {
        [Display(Name = "Ulaşım Harcamaları")]
        Transportation = 1,
        [Display(Name = "Konaklama Harcamaları")]
        Accommodation,
        [Display(Name = "Yemek Harcamaları")]
        Food,
        [Display(Name = "Diğer Harcamalar")]
        Other
    }
}
