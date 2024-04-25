using System;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.CompanyVMs;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace IKProjesi.UI.Services.CompanyManager
{
    public interface ICompanyManagerService
    {
       
        Task<CreateCompanyManagerVm> CreateCompanyManager([FromBody] CreateCompanyManagerVm createCompanyManager);

        Task<List<ListCompanyManagerVm>> GetCompanyManagers();

    }
}

