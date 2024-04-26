using System;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.SiteManagerVMs;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace IKProjesi.UI.Services.CompanyManager
{
	public interface ICompanyManagerApiService
	{

        [Post("/api/SiteManager/AddCompanyManager")]
        Task CreateCompanyManager( CreateCompanyManagerVm model);

        

        [Get("/api/SiteManager/GetAllCompanyManagers")]
        Task<List<ListCompanyManagerVm>> GetCompanyManagers();

        [Get("/api/CompanyManager/CompanyManagerSummary/{id}")]
        Task<SummaryCompanyManagerVm> GetCompanyManagerSummary(int id);

        [Get("/api/CompanyManager/CompanyManagerDetails/{id}")]
        Task<DetailsCompanyManagerVm> GetCompanyManagerDetails(int id);

        [Put("/api/CompanyManager/CompanyManagerUpdate")]
        Task GetCompanyManagerUpdate(UpdateCompanyManagerVm updateCompanyManager);

    }
}

