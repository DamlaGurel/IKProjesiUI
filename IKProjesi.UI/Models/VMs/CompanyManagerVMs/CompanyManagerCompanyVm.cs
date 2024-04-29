using System;
using IKProjesi.UI.Models.VMs.CompanyVMs;

namespace IKProjesi.UI.Models.VMs.CompanyManagerVMs
{
	public class CompanyManagerCompanyVm
	{
		public CreateCompanyManagerVm CreateCompanyManagerVm { get; set; }
        public List<CompanyListVM>? Companies { get; set; }

    }
}

