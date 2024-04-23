using IKProjesi.UI.Models.VMs.CompanyVMs;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace IKProjesi.UI.Services.Company
{
    public interface ICompanyApiService
    {
        [Get("/api/SiteManager/Index")]
        Task<List<CompanyListVM>> GetCompanies();

        //[Get("/api/Company/Create")]
        //Task<IActionResult> Create();

        [Post("/api/SiteManager/CreateCompany")]
        Task<IActionResult> CreateCompany([FromBody] CreateCompanyVM model);

        [Get("/api/SiteManager/CompanyDetails/{id}")]
        Task<CompanyDetailsVM> GetCompanyDetails(int id);
    }
}
