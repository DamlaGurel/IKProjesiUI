using IKProjesi.UI.Models.VMs.CompanyVMs;
using Microsoft.AspNetCore.Mvc;

namespace IKProjesi.UI.Services.Company
{
    public interface ICompanyService
    {
        Task<List<CompanyListVM>> GetCompanies();

        //Task<IActionResult> Create();

        Task<IActionResult> CreateCompany(CreateCompanyVM model);

        Task<CompanyDetailsVM> GetCompanyDetails(int id);
    }
}
