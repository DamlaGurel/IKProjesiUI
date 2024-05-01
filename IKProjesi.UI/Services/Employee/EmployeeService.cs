using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.EmployeeVMs;
using IKProjesi.UI.Services.CompanyManager;

namespace IKProjesi.UI.Services.Employee
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeApiService _employeeApiService;

        public EmployeeService(IEmployeeApiService employeeApiService)
        {
            _employeeApiService = employeeApiService;
        }

        public async Task CreateEmployee(CreateEmployeeVm model)
        {
            await _employeeApiService.CreateEmployee(model);
        }

        public async Task<SummaryEmployeeVm> GetEmployeeSummary(int id)
        {
            return await _employeeApiService.GetEmployeeSummary(id);
        }

        public async Task<EmployeeDetailsVm> GetEmployeeDetails(int id)
        {
            return await _employeeApiService.GetEmployeeDetails(id);
        }
    }
}
