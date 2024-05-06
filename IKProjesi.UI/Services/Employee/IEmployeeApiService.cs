using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.EmployeeVMs;
using Refit;

namespace IKProjesi.UI.Services.Employee
{
    public interface IEmployeeApiService
    {
        [Post("/api/CompanyManager/CreateEmployee")]
        Task<CreateEmployeeVm> CreateEmployee(CreateEmployeeVm model);

        [Get("/api/Employee/GetEmployeeSummary/{id}")]
        Task<SummaryEmployeeVm> GetEmployeeSummary(int id);

        [Get("/api/Employee/GetEmployeeDetails/{id}")]
        Task<EmployeeDetailsVm> GetEmployeeDetails(int id);

        [Put("/api/Employee/UpdateEmployee")]
        Task UpdateEmployee(UpdateEmployeeVm model);

        [Get("/api/Employee/GetEmployeeById/{id}")]
        Task<UpdateEmployeeVm> GetEmployeeById(int id);
    }

}
