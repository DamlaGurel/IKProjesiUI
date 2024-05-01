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


        [Get("/api/CompanyManager/GetCompanyManagerSummary/{id}")]
        Task<SummaryCompanyManagerVm> GetCompanyManagerSummary(int id);


        [Get("/api/CompanyManager/GetCompanyManagerDetails/{id}")]
        Task<DetailsCompanyManagerVm> GetCompanyManagerDetails(int id);

        [Get("/api/CompanyManager/GetCompanyManagerById/{id}")]
        Task<UpdateCompanyManagerVm> GetCompanyManagerById(int id);

        [Put("/api/CompanyManager/GetCompanyManagerUpdate")]
        Task GetCompanyManagerUpdate(UpdateCompanyManagerVm updateCompanyManager);

    }
}

