using IKProjesi.UI.Models.VMs.AdvancePaymentVMs;
using IKProjesi.UI.Models.VMs.EmployeeVMs;
using IKProjesi.UI.Models.VMs.ExpenseVMs;
using IKProjesi.UI.Models.VMs.OffDayVMs;
using Refit;

namespace IKProjesi.UI.Services.Employee
{
    public interface IEmployeeApiService
    {
        #region Employee
        [Post("/api/CompanyManager/CreateEmployee")]
        Task CreateEmployee(CreateEmployeeVM model);

        [Get("/api/Employee/GetEmployeeSummary/{id}")]
        Task<SummaryEmployeeVM> GetEmployeeSummary(int id);

        [Get("/api/Employee/GetEmployeeDetails/{id}")]
        Task<EmployeeDetailsVM> GetEmployeeDetails(int id);

        [Put("/api/Employee/UpdateEmployee")]
        Task<UpdateEmployeeVM> UpdateEmployee(UpdateEmployeeVM model);

        [Get("/api/Employee/GetEmployeeById/{id}")]
        Task<UpdateEmployeeVM> GetEmployeeById(int id);
        #endregion


        #region Expense
        [Post("/api/Employee/CreateExpense")]
        Task CreateExpense(CreateExpenseVM model);

        [Get("/api/Employee/ListExpense/{id}")]
        Task<List<ListExpenseVM>> ListExpense(int id);
        #endregion


        #region Off Day
        [Post("/api/Employee/CreateOffDay")]
        Task CreateTakeDayOff(CreateOffDayVM model);

        [Get("/api/Employee/ListOffDay/{id}")]
        Task<List<ListOffDayVM>> ListOffDay(int id );
        #endregion


        #region Advance Payment
        [Post("/api/Employee/CreateAdvancePayment")]
        Task CreateAdvancePayment(CreateAdvancePaymentVM model);

        [Get("/api/Employee/ListAdvancePayment/{id}")]
        Task<List<ListAdvancePaymentVM>> ListAdvancePayment(int id);

        [Get("/api/Employee/TotalAdvancePayment/{employeeId}")]
        Task<double?> TotalAdvancePayment(int employeeId);
        #endregion
    }
}
