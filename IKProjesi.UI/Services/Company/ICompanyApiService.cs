using IKProjesi.UI.Models.VMs.CompanyVMs;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace IKProjesi.UI.Services.Company
{
    public interface ICompanyApiService
    {
        [Get("/api/SiteManager/CompanyIndex")]
        Task<List<CompanyListVM>> GetCompanies();

        [Post("/api/SiteManager/CreateCompany")]
        Task<IActionResult> CreateCompany(CreateCompanyVM model);

        [Get("/api/SiteManager/CompanyDetails/{id}")]
        Task<CompanyDetailsVM> GetCompanyDetails(int id);
    }
}
