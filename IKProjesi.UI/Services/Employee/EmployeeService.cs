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
            if (model.File is not null)
            {
                using var memorystream = new MemoryStream();
                await model.File.CopyToAsync(memorystream);

                if (memorystream.Length < 2097152)
                    model.FileByteArray = memorystream.ToArray();
            }

            model.ExpenseTypeId = (int)model.ExpenseType;
            model.MoneyTypeId = (int)model.MoneyType;

            await _employeeApiService.CreateExpense(model);
        }
    }
}
