using IKProjesi.UI.Models.VMs.CompanyVMs;
using Microsoft.AspNetCore.Mvc;
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

        //public async Task<IActionResult> Create()
        //{
        //   return await _companyApiService.Create();            
        //}

        public async Task<IActionResult> CreateCompany(CreateCompanyVM model)
        {
          return  await _companyApiService.CreateCompany(model);

        }

        public async Task<CompanyDetailsVM> GetCompanyDetails(int id)
        {
            return await _companyApiService.GetCompanyDetails(id);
        }
    }
}
