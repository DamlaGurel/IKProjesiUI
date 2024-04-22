using IKProjesi.UI.Models.VMs.CompanyVMs;
using Refit;

namespace IKProjesi.UI.Services.Company
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyApiService _companyApiService;

        public CompanyService(ICompanyApiService companyApiService)
        {
            _companyApiService = companyApiService;
        }

        public async Task<List<CompanyListVM>> GetCompanies()
        {

            return await _companyApiService.GetCompanies();
        }
    }
}
