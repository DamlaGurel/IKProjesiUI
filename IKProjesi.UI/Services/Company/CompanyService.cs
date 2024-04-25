using IKProjesi.UI.Models.VMs.CompanyVMs;
using Microsoft.AspNetCore.Mvc;
using NuGet.ProjectModel;
using Refit;
using System.Reflection;

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

        public async Task<IActionResult> CreateCompany(CreateCompanyVM model)
        {
            byte[] logoBytes = null;

            if (model.Logo is not null)
            {
                logoBytes =await  SaveLogo(model.Logo);
            }

            model.LogoBytes = logoBytes;

            return  await _companyApiService.CreateCompany(model);

        }

        public async Task<CompanyDetailsVM> GetCompanyDetails(int id)
        {
            return await _companyApiService.GetCompanyDetails(id);
        }

        public async Task<byte[]> SaveLogo(IFormFile logo)
        {
            var logoFile = logo;

            byte[] logoBytes = null;

            using (var memoryStream = new MemoryStream())
            {
                await logoFile.CopyToAsync(memoryStream);
                logoBytes = memoryStream.ToArray();
            }

            return logoBytes;
        }
    }
}
