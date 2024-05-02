using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Xml.Linq;

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

