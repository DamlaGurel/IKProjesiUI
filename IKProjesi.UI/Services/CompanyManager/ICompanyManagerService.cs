using System;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.CompanyVMs;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace IKProjesi.UI.Services.CompanyManager
{
    public interface ICompanyManagerService
    {
        Task CreateCompanyManager( CreateCompanyManagerVM model);
        Task<List<ListCompanyManagerVM>> GetCompanyManagers();
        Task<SummaryCompanyManagerVM> GetCompanyManagerSummary(int id);
        Task GetCompanyManagerUpdate(UpdateCompanyManagerVM updateCompanyManager);
        Task<DetailsCompanyManagerVM> GetCompanyManagerDetails(int id);

    }
}

