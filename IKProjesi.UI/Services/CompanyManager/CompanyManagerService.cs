using System;
using System.Reflection;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.CompanyVMs;
using IKProjesi.UI.Models.VMs.SiteManagerVMs;
using IKProjesi.UI.Services.Company;
using IKProjesi.UI.Services.SiteManager;
using Microsoft.AspNetCore.Mvc;
using Refit;


namespace IKProjesi.UI.Services.CompanyManager
{
    public class CompanyManagerService : ICompanyManagerService
    {
        private readonly ICompanyManagerApiService _companyManagerApiService;

        public CompanyManagerService(ICompanyManagerApiService companyManagerApiService)
        {
            _companyManagerApiService = companyManagerApiService;
        }

        public async Task CreateCompanyManager(CreateCompanyManagerVm model)
        {
            await _companyManagerApiService.CreateCompanyManager(model);


        }


        public async Task<List<ListCompanyManagerVm>> GetCompanyManagers()
        {
            return await _companyManagerApiService.GetCompanyManagers();

        }

        public async Task<SummaryCompanyManagerVm> GetCompanyManagerSummary(int id)
        {
            return await _companyManagerApiService.GetCompanyManagerSummary(id);
        }

        public async Task GetCompanyManagerUpdate(UpdateCompanyManagerVm updateCompanyManager)
        {
            await _companyManagerApiService.GetCompanyManagerUpdate(updateCompanyManager);
        }

        public async Task<DetailsCompanyManagerVm> GetCompanyManagerDetails(int id)
        {
            return await _companyManagerApiService.GetCompanyManagerDetails(id);

        }

    }
}

