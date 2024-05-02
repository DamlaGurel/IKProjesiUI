using IKProjesi.UI.Models.VMs.CompanyVMs;
using Microsoft.AspNetCore.Mvc;

namespace IKProjesi.UI.Services.Company
{
    public interface ICompanyService
    {
        Task<List<CompanyListVM>> GetCompanies();
        Task CreateCompany(CreateCompanyVM model);
        Task<CompanyDetailsVM> GetCompanyDetails(int id);
        Task<string> SaveLogo(IFormFile logo);
    }
}
