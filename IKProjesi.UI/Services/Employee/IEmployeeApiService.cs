using IKProjesi.UI.Models.VMs.AdvancePaymentVMs;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.EmployeeVMs;
using IKProjesi.UI.Models.VMs.ExpenseVMs;
using IKProjesi.UI.Models.VMs.OffDayVMs;
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


        [Post("/api/Employee/CreateOffDay")]
        Task CreateTakeDayOff(CreateOffDayVM model);

        [Get("/api/Employee/ListOffDay/{id}")]
        Task<List<ListOffDayVM>> ListOffDay(int id );


        [Post("/api/Employee/CreateAdvancePayment")]
        Task CreateAdvancePayment(CreateAdvancePaymentVM model);

        [Get("/api/Employee/ListAdvancePayment")]
        Task<List<ListAdvancePaymentVM>> AdvancePayments();


        [Put("/api/Employee/UpdateEmployee")]
        Task UpdateEmployee(UpdateEmployeeVM model);

        [Get("/api/Employee/GetEmployeeById/{id}")]
        Task<UpdateEmployeeVM> GetEmployeeById(int id);
    }
}
