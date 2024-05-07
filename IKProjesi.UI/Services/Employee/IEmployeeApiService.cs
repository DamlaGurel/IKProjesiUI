using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.EmployeeVMs;

using Refit;

namespace IKProjesi.UI.Services.Employee
{
    public interface IEmployeeApiService
    {
        [Post("/api/CompanyManager/CreateEmployee")]
        Task CreateEmployee(CreateEmployeeVM model);

        [Get("/api/Employee/GetEmployeeSummary/{id}")]
        Task<SummaryEmployeeVM> GetEmployeeSummary(int id);

        [Get("/api/Employee/GetEmployeeDetails/{id}")]
        Task<EmployeeDetailsVM> GetEmployeeDetails(int id);

        [Post("/api/Employee/CreateExpense")]
        Task CreateExpense(CreateExpenseVM model);


        [Post("/api/Employee/CreateTakeDayOff")]
        Task CreateTakeDayOff(CreateOffDayVM model);

        [Get("/api/Employee/ListTakeDayOff/{id}")]
        Task<List<ListOffDaysVM>> ListTakeDayOff(int id );




        [Post("/api/Employee/CreateAdvancePayment")]
        Task CreateAdvancePayment(CreateAdvancePaymentVM model);
    }
}
