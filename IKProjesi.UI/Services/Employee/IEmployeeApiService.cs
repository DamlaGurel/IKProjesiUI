using IKProjesi.UI.Models.VMs.EmployeeVMs;
using Refit;

namespace IKProjesi.UI.Services.Employee
{
    public interface IEmployeeApiService
    {
        [Post("/api/CompanyManager/CreateEmployee")]
        Task CreateEmployee(CreateEmployeeVM model);

        [Post("/api/Employee/CreateExpense")]
        Task CreateExpense(CreateExpenseVM model);
    }

}
