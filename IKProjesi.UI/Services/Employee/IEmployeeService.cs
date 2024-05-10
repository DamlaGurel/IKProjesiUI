using IKProjesi.UI.Models.VMs.AdvancePaymentVMs;
using IKProjesi.UI.Models.VMs.EmployeeVMs;
using IKProjesi.UI.Models.VMs.ExpenseVMs;
using IKProjesi.UI.Models.VMs.OffDayVMs;

namespace IKProjesi.UI.Services.Employee
{
    public interface IEmployeeService
    {
        #region Employee
        Task CreateEmployee(CreateEmployeeVM model);
        Task<SummaryEmployeeVM> GetEmployeeSummary(int id);
        Task<EmployeeDetailsVM> GetEmployeeDetails(int id);
        Task<UpdateEmployeeVM> UpdateEmployee(UpdateEmployeeVM model);
        Task<UpdateEmployeeVM> GetEmployeeById(int id);
        #endregion

        #region Expense
        Task CreateExpense(CreateExpenseVM model);
        Task<List<ListExpenseVM>> ListExpense(int id);
        #endregion

        #region Off Day
        Task CreateOffDay(CreateOffDayVM model);
        Task<List<ListOffDayVM>> ListOffDay(int id);
        #endregion

        #region Advance Payment
        Task CreateAdvancePayment(CreateAdvancePaymentVM model);
        Task<List<ListAdvancePaymentVM>> ListAdvancePayment(int id);
        #endregion
    }
}
