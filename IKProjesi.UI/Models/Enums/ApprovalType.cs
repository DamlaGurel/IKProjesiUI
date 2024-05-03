using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace IKProjesi.UI.Models.Enums
{
	public enum ApprovalType
	{
        [Display(Name = "Onay Bekliyor")]
        Waiting = 1,
        [Display(Name = "Onaylandı")]
        Done,
        [Display(Name = "Onay Reddedildi")]
        Deny,
        [Display(Name = "Onay İptal Edildi")]
        Reject
    }
}

