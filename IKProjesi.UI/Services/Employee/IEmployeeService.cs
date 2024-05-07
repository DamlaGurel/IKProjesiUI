using IKProjesi.UI.Models.VMs.AdvancePaymentVMs;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.EmployeeVMs;
using IKProjesi.UI.Models.VMs.ExpenseVMs;
using IKProjesi.UI.Models.VMs.OffDayVMs;

namespace IKProjesi.UI.Services.Employee
{
    public interface IEmployeeService
    {
        Task CreateEmployee(CreateEmployeeVM model);
        Task<SummaryEmployeeVM> GetEmployeeSummary(int id);
        Task<EmployeeDetailsVM> GetEmployeeDetails(int id);
        Task CreateExpense(CreateExpenseVM model);
        Task<List<ListExpenseVM>> Expenses(int id);

        Task CreateOffDay(CreateOffDayVM model);
        Task<List<ListOffDayVM>> ListOffDay(int id);


        Task CreateAdvancePayment(CreateAdvancePaymentVM model);
        Task<List<ListAdvancePaymentVM>> AdvancePayments(int id);


        Task<UpdateEmployeeVM> UpdateEmployee(UpdateEmployeeVM model);
        Task<UpdateEmployeeVM> GetEmployeeById(int id);
        
    }
}
