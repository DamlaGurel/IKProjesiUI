using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.EmployeeVMs;

namespace IKProjesi.UI.Services.Employee
{
    public interface IEmployeeService
    {
        Task CreateEmployee(CreateEmployeeVM model);
        Task<SummaryEmployeeVM> GetEmployeeSummary(int id);
        Task<EmployeeDetailsVM> GetEmployeeDetails(int id);
        Task CreateExpense(CreateExpenseVM model);
        Task<List<ListExpenseVM>> Expenses(int id);

        Task CreateTakeDayOff(CreateOffDayVM model);
        Task<List<ListOffDaysVM>> ListTakeDayOff(int id);


        Task CreateAdvancePayment(CreateAdvancePaymentVM model);
        Task<List<ListAdvancePaymentVM>> AdvancePayments();


        Task<UpdateEmployeeVM> UpdateEmployee(UpdateEmployeeVM model);
        Task<UpdateEmployeeVM> GetEmployeeById(int id);
        
    }
}
