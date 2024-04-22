using IKProjesi.UI.Models.VMs.CompanyVMs;

namespace IKProjesi.UI.Services.Company
{
    public interface ICompanyService
    {
        Task<List<CompanyListVM>> GetCompanies();
    }
}
