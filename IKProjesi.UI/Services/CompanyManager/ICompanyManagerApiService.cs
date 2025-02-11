﻿using IKProjesi.UI.Models.VMs.AdvancePaymentVMs;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.ExpenseVMs;
using IKProjesi.UI.Models.VMs.OffDayVMs;
using Refit;

namespace IKProjesi.UI.Services.CompanyManager
{
    public interface ICompanyManagerApiService
    {
        #region CompanyManager
        [Post("/api/SiteManager/CreateCompanyManager")]
        Task CreateCompanyManager(CreateCompanyManagerVM model);

        [Get("/api/SiteManager/GetAllCompanyManagers")]
        Task<List<ListCompanyManagerVM>> GetCompanyManagers();

        [Get("/api/CompanyManager/GetCompanyManagerSummary/{id}")]
        Task<SummaryCompanyManagerVM> GetCompanyManagerSummary(int id);

        [Get("/api/CompanyManager/GetCompanyManagerDetails/{id}")]
        Task<DetailsCompanyManagerVM> GetCompanyManagerDetails(int id);

        [Get("/api/CompanyManager/GetCompanyManagerById/{id}")]
        Task<UpdateCompanyManagerVM> GetCompanyManagerById(int id);

        [Put("/api/CompanyManager/GetCompanyManagerUpdate")]
        Task<UpdateCompanyManagerVM> GetCompanyManagerUpdate(UpdateCompanyManagerVM updateCompanyManager);
        #endregion

        #region OffDay
        [Get("/api/CompanyManager/ListApprovalForOffDay")]
        Task<List<ListWaitingApprovalForOffDayVM>> ListApprovalForOffDay();

        [Put("/api/CompanyManager/UpdateApprovalForOffDay")]
        Task ApprovalForOffDay(UpdateOffDayVM model);


        [Get("/api/CompanyManager/GetApprovalForOffDay/{id}")]
        Task<UpdateOffDayVM> GetApprovalForOffDay(int id);
        #endregion

        #region Expense
        [Get("/api/CompanyManager/ListApprovalForExpense")]
        Task<List<ListWaitingApprovalForExpenseVM>> ListApprovalForExpense(int id);

        [Put("/api/CompanyManager/UpdateApprovalForExpense")]
        Task ApprovalForExpense(UpdateExpenseVM model);


        [Get("/api/CompanyManager/GetApprovalForExpense/{id}")]
        Task<UpdateExpenseVM> GetApprovalForExpense(int id);
        #endregion

        #region Advance Payment
        [Get("/api/CompanyManager/ListApprovalForAdvancePayment/{id}")]
        Task<List<ListWaitingApprovalForAdvancePaymentVM>> ListApprovalForAdvancePayment(int id);

        [Put("/api/CompanyManager/UpdateApprovalForAdvancePayment")]
        Task ApprovalForAdvancePayment(UpdateAdvancePaymentVM model);


        [Get("/api/CompanyManager/GetApprovalForAdvancePayment/{id}")]
        Task<UpdateAdvancePaymentVM> GetApprovalForAdvancePayment(int id);
        #endregion

    }
}

