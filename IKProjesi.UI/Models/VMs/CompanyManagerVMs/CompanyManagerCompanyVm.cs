using System;
using IKProjesi.UI.Models.VMs.CompanyVMs;

namespace IKProjesi.UI.Models.VMs.CompanyManagerVMs
{
	public class CompanyManagerCompanyVM
	{
		public CreateCompanyManagerVM CreateCompanyManagerVM { get; set; }
        public List<CompanyListVM>? Companies { get; set; }

    }
}

