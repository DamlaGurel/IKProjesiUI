using System.ComponentModel.DataAnnotations;

namespace IKProjesi.UI.Models.Enums
{
    public enum AdvanceType
    {
        [Display(Name = "Ücret Avansı")]
        WageAdvance =1,
        [Display(Name = "İş Avansı")]
        BusinessAdvance,
        [Display(Name = "Yıllık Ücretli Avans")]
        AnnualPaidAdvance
    }
}
