using System;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using Refit;

namespace IKProjesi.UI.Services.CompanyManager
{
    public interface ICompanyManager
    {
        [Post(path: "SiteManager")]
        Task CreateCompanyManager([Body] CreateCompanyManagerVm createCompanyManager);

        [Get(path: "SiteManager")]
        Task GetCpmpanyManager([Body] ListCompanyManagerVm listCompanyManagers);
    }
}

