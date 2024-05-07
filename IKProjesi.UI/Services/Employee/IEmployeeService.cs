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

        Task CreateTakeDayOff(CreateOffDayVM model);
        Task<List<ListOffDaysVM>> ListTakeDayOff(int id);


        Task CreateAdvancePayment(CreateAdvancePaymentVM model);

        Task<UpdateEmployeeVm> UpdateEmployee(UpdateEmployeeVm model);
        Task<UpdateEmployeeVm> GetEmployeeById(int id);
        Task<List<ListAdvancePaymentVM>> AdvancePayments();
    }
}
