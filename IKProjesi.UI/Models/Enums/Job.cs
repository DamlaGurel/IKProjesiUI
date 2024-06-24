using System;
using System.ComponentModel.DataAnnotations;
namespace IKProjesi.UI.Models.Enums
{
    public enum Job
    {
        [Display(Name = "Super Admin")]
        SUPERADMIN = 1,
        [Display(Name = "Site Manager")]
        SITEMANAGER,
        [Display(Name = "Company Manager")]
        COMPANYMANAGER,
        [Display(Name = "Employee")]
        EMPLOYEE
    }
}

