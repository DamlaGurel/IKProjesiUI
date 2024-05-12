using IKProjesi.UI.Models.VMs.AdvancePaymentVMs;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.ExpenseVMs;
using IKProjesi.UI.Models.VMs.OffDayVMs;

namespace IKProjesi.UI.Services.CompanyManager
{
    public interface ICompanyManagerService
    {
        #region CompanyManager
        Task CreateCompanyManager(CreateCompanyManagerVM model);
        Task<List<ListCompanyManagerVM>> GetCompanyManagers();
        Task<SummaryCompanyManagerVM> GetCompanyManagerSummary(int id);
        Task<UpdateCompanyManagerVM> GetCompanyManagerUpdate(UpdateCompanyManagerVM updateCompanyManager);
        Task<DetailsCompanyManagerVM> GetCompanyManagerDetails(int id);
        Task<UpdateCompanyManagerVM> GetCompanyManagerById(int id);
        #endregion

        #region Off Day
        Task<List<ListWaitingApprovalForOffDayVM>> ListApprovalForOffDay(int id);
        Task GetApprovalForOffDay(UpdateOffDayVM model);
        Task<UpdateOffDayVM> GetApprovalForOffDay(int id);
        #endregion

        #region Expense
        Task<List<ListWaitingApprovalForExpenseVM>> ListApprovalForExpense(int id);
        Task GetApprovalForExpense(UpdateExpenseVM model);
        Task<UpdateExpenseVM> GetApprovalForExpense(int id);
        #endregion

        #region CompanyManager
        Task<List<ListWaitingApprovalForAdvancePaymentVM>> ListApprovalForAdvancePayment(int id);
        Task GetApprovalForAdvancePayment(UpdateAdvancePaymentVM model);
        Task<UpdateAdvancePaymentVM> GetApprovalForAdvancePayment(int id);
        #endregion

       

    }
}


