using IKProjesi.UI.Models.VMs.EmployeeVMs;

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

        public async Task CreateExpense(CreateExpenseVM model)
        {
            await _employeeApiService.CreateExpense(model);
        }
    }
}
