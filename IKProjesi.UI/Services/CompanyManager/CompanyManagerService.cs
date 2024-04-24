using System;
using System.Reflection;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.CompanyVMs;
using IKProjesi.UI.Services.Company;
using Microsoft.AspNetCore.Mvc;

namespace IKProjesi.UI.Services.CompanyManager
{
    public class CompanyManagerService : ICompanyManagerService
    {
        private readonly ICompanyManagerApiService _companyManagerApiService;

        public CompanyManagerService(ICompanyManagerApiService companyManagerApiService)
        {
            _companyManagerApiService = companyManagerApiService;
        }

        public async Task<CreateCompanyManagerVm> CreateCompanyManager([FromBody] CreateCompanyManagerVm createCompanyManager)
        {
                return await _companyManagerApiService.CreateCompanyManager(createCompanyManager);

        }

        public async Task<List<ListCompanyManagerVm>> GetCompanyManagers()
        {
            return await _companyManagerApiService.GetCompanyManagers();

        }

    //    public async Task<IActionResult> CreateCompanyManager([FromBody] CreateCompanyManagerVm createCompanyManager)
    //    {
    //        return await _companyManagerApiService.CreateCompanyManager(createCompanyManager);
    //    }
    }

}

