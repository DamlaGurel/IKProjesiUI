using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.EmployeeVMs;

namespace IKProjesi.UI.Services.Employee
{
    public interface IEmployeeService
    {
        Task CreateEmployee(CreateEmployeeVM model);
        Task CreateExpense(CreateExpenseVM model);
        Task CreateTakeDayOff(CreateOffDayVm model);
        Task<List<ListOffDaysVm>> ListTakeDayOff(int id);



    }
}
