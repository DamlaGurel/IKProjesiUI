using System;
using Refit;

namespace IKProjesi.Application.Services.CompanyManager
{
	public interface ICompanyManager
	{
		[Post(path: "SiteManager")]
		Task CreateCompanyManager([Body] CreateCompanyManagerVm createCompanyManager);

		[Get(path: "SiteManager")]
		Task GetCpmpanyManager([Body] ListCompanyManagerVm listCompanyManagers);
	}
}

