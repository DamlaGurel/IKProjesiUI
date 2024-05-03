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

        public async Task CreateAdvancePayment(CreateAdvancePaymentVM model)
        {
            await _employeeApiService.CreateAdvancePayment(model);
        }

        public async Task CreateEmployee(CreateEmployeeVM model)
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

        public async Task CreateExpense(CreateExpenseVM model)
        {
            await _employeeApiService.CreateExpense(model);
        }
    }
}
