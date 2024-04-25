using IKProjesi.UI.Models.VMs.CompanyVMs;
using Microsoft.AspNetCore.Http;
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

        public async Task CreateCompany(CreateCompanyVM model)
        {
   
            if (model.Logo is not null)
            {
                model.LogoString =await SaveLogo(model.Logo);
            }

            await _companyApiService.CreateCompany(model);

        }

        public async Task<CompanyDetailsVM> GetCompanyDetails(int id)
        {
            var company= await _companyApiService.GetCompanyDetails(id);                     
            return company;
        }

        public async Task<string> SaveLogo(IFormFile logo)
        {
            var logoFile = logo;

            byte[] logoBytes = null;

            using (var memoryStream = new MemoryStream())
            {
                await logoFile.CopyToAsync(memoryStream);

                if (memoryStream.Length < 2097152)
                {
                    logoBytes = memoryStream.ToArray();
                }
                else
                {
                    logoBytes = null;
                }
            }

            string logoString=Convert.ToBase64String(logoBytes);
            return logoString;
        }

      
        }
}
