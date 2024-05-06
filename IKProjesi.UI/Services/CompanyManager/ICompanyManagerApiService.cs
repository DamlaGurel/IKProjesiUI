using System;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.SiteManagerVMs;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace IKProjesi.UI.Services.CompanyManager
{
	public interface ICompanyManagerApiService
	{

        [Post("/api/SiteManager/CreateCompanyManager")]
        Task CreateCompanyManager( CreateCompanyManagerVM model);

        [Get("/api/SiteManager/GetAllCompanyManagers")]
        Task<List<ListCompanyManagerVM>> GetCompanyManagers();

        [Get("/api/CompanyManager/GetCompanyManagerSummary/{id}")]
        Task<SummaryCompanyManagerVM> GetCompanyManagerSummary(int id);

        [Get("/api/CompanyManager/GetCompanyManagerDetails/{id}")]
        Task<DetailsCompanyManagerVM> GetCompanyManagerDetails(int id);

        [Put("/api/CompanyManager/GetCompanyManagerUpdate")]
        Task GetCompanyManagerUpdate(UpdateCompanyManagerVM updateCompanyManager);

        [Get("/api/CompanyManager/ListApprovalForOffDay")]
        Task<List<ListWaitingApprovalForOffDaysVm>> ListApprovalForOffDay();

        [Put("/api/CompanyManager/UpdateApprovalForOffDay")]
        Task ApprovalForOffDay(UpdateDayOffVm model);


        [Get("/api/CompanyManager/GetApprovalForOffDay/{id}")]
        Task<UpdateDayOffVm> GetApprovalForOffDay(int id);
        
    }
}

