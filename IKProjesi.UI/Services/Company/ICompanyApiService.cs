using IKProjesi.UI.Models.VMs.CompanyVMs;
using Refit;

namespace IKProjesi.UI.Services.Company
{
    public interface ICompanyApiService
    {
        [Get("/api/Company/Index")]
        Task<List<CompanyListVM>> GetCompanies();
    }
}
