using IKProjesi.UI.Models.VMs.EmployeeVMs;

namespace IKProjesi.UI.Services.Employee
{
    public interface IEmployeeService
    {
        Task CreateEmployee(CreateEmployeeVm model);
        Task<SummaryEmployeeVm> GetEmployeeSummary(int id);
        Task<EmployeeDetailsVm> GetEmployeeDetails(int id);
    }
}
