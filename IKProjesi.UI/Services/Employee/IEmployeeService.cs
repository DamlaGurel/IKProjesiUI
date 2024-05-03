using IKProjesi.UI.Models.VMs.EmployeeVMs;

namespace IKProjesi.UI.Services.Employee
{
    public interface IEmployeeService
    {
        Task CreateEmployee(CreateEmployeeVm model);
        Task<SummaryEmployeeVm> GetEmployeeSummary(int id);
        Task<EmployeeDetailsVm> GetEmployeeDetails(int id);
        Task CreateEmployee(CreateEmployeeVM model);
        Task CreateExpense(CreateExpenseVM model);

        Task CreateAdvancePayment(CreateAdvancePaymentVM model);
    }
}
