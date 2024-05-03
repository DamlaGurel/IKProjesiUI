using IKProjesi.UI.Models.Enums;
using IKProjesi.UI.Models.VMs.EmployeeVMs;
using System.IO.Compression;

namespace IKProjesi.UI.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeApiService _employeeApiService;

        public EmployeeService(IEmployeeApiService employeeApiService)
        {
            _employeeApiService = employeeApiService;
        }

        public async Task CreateEmployee(CreateEmployeeVM model)
        {
            await _employeeApiService.CreateEmployee(model);
        }

        public async Task CreateExpense(CreateExpenseVM model)
        {
            EnumExtensions.GetEnumValue(model);
            await _employeeApiService.CreateExpense(model);
        }
    }
}
