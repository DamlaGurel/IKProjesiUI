using System;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.CompanyVMs;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace IKProjesi.UI.Services.CompanyManager
{
    public interface ICompanyManagerService
    {

        Task CreateCompanyManager( CreateCompanyManagerVm model);

        Task<List<ListCompanyManagerVm>> GetCompanyManagers();
        Task<SummaryCompanyManagerVm> GetCompanyManagerSummary(int id);
        Task GetCompanyManagerUpdate(UpdateCompanyManagerVm updateCompanyManager);
        Task<DetailsCompanyManagerVm> GetCompanyManagerDetails(int id);

    }
}

