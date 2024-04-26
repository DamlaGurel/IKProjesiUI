using System;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
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


    }
}

