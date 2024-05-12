using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace IKProjesi.UI.Models.Enums
{
    public enum Job
    {
        [Display(Name = "Süper Admin")]
        SUPERADMIN = 1,
        [Display(Name = "Site Yöneticisi")]
        SITEMANAGER,
        [Display(Name = "Şirket Yöneticisi")]
        COMPANYMANAGER,
        [Display(Name = "Personel")]
        EMPLOYEE
    }
}

