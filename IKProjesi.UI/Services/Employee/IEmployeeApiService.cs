using IKProjesi.UI.Models.VMs.EmployeeVMs;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace IKProjesi.UI.Services.Employee
{
    public interface IEmployeeApiService
    {
        [Post("/api/CompanyManager/CreateEmployee")]
        Task CreateEmployee(CreateEmployeeVM model);

        [Post("/api/Employee/CreateExpense")]
        Task CreateExpense(CreateExpenseVM model);

        [Post("/api/Employee/CreateTakeDayOff")]
        Task CreateTakeDayOff(CreateOffDayVm model);

        [Get("/api/Employee/ListTakeDayOff/{id}")]
        Task<List<ListOffDaysVm>> ListTakeDayOff(int id );


    }

}
