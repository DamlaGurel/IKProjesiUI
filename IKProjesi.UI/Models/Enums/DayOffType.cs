using System.ComponentModel.DataAnnotations;

namespace IKProjesi.UI.Models.Enums
{
    public enum DayOffType
    {
        [Display(Name = "İdari İzin")]
        administrativeLeave = 1,
        [Display(Name = "Hastalık İzni&Rapor")]
        sickDay,
        [Display(Name = "Yıllık İzin")]
        annualLeave
    }
}
