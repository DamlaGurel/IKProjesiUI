using IKProjesi.UI.Models.VMs.EmployeeVMs;

namespace IKProjesi.UI.Services.Employee
{
    public interface IEmployeeService
    {
        Task CreateEmployee(CreateEmployeeVM model);
        Task<SummaryEmployeeVM> GetEmployeeSummary(int id);
        Task<EmployeeDetailsVM> GetEmployeeDetails(int id);
        Task CreateExpense(CreateExpenseVM model);

        Task CreateAdvancePayment(CreateAdvancePaymentVM model);
        Task<List<ListAdvancePaymentVM>> AdvancePayments();
    }
}
