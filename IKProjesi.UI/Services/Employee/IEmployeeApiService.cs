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

        [Get("/api/Employee/ListExpense/{id}")]
        Task<List<ListExpenseVM>> ListExpense(int id);


        [Post("/api/Employee/CreateTakeDayOff")]
        Task CreateTakeDayOff(CreateOffDayVM model);

        [Get("/api/Employee/ListTakeDayOff/{id}")]
        Task<List<ListOffDaysVM>> ListTakeDayOff(int id );


        [Post("/api/Employee/CreateAdvancePayment")]
        Task CreateAdvancePayment(CreateAdvancePaymentVM model);

        [Get("/api/Employee/ListAdvancePayment/{id}")]
        Task<List<ListAdvancePaymentVM>> AdvancePayments(int id);


        [Put("/api/Employee/UpdateEmployee")]
        Task UpdateEmployee(UpdateEmployeeVM model);

        [Get("/api/Employee/GetEmployeeById/{id}")]
        Task<UpdateEmployeeVM> GetEmployeeById(int id);
    }
}
