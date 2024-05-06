using System;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.CompanyVMs;
using IKProjesi.UI.Models.VMs.EmployeeVMs;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace IKProjesi.UI.Services.CompanyManager
{
    public interface ICompanyManagerService
    {


        Task CreateCompanyManager(CreateCompanyManagerVM model);
        

        Task<List<ListCompanyManagerVM>> GetCompanyManagers();
        Task<SummaryCompanyManagerVM> GetCompanyManagerSummary(int id);
        Task GetCompanyManagerUpdate(UpdateCompanyManagerVM updateCompanyManager);
        Task<DetailsCompanyManagerVM> GetCompanyManagerDetails(int id);

        Task<List<ListWaitingApprovalForOffDaysVM>> ListApprovalForOffDay();


        Task GetApprovalForOffDay(UpdateDayOffVM model);

        Task<UpdateDayOffVM> GetApprovalForOffDay(int id);
        

        Task<UpdateCompanyManagerVM> GetCompanyManagerById(int id);

    }
}


