using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.Enums;
using IKProjesi.UI.Models.VMs.EmployeeVMs;
using IKProjesi.UI.Services.CompanyManager;
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

        public async Task CreateAdvancePayment(CreateAdvancePaymentVM model)
        {
            model.AdvanceTypeId = (int)model.AdvanceType;
            model.MoneyTypeId = (int)model.MoneyType;
            await _employeeApiService.CreateAdvancePayment(model);
        }

        public async Task CreateEmployee(CreateEmployeeVM model)
        {
            await _employeeApiService.CreateEmployee(model);
        }

        public async Task<SummaryEmployeeVM> GetEmployeeSummary(int id)
        {
            return await _employeeApiService.GetEmployeeSummary(id);
        }

        public async Task<EmployeeDetailsVM> GetEmployeeDetails(int id)
        {
            return await _employeeApiService.GetEmployeeDetails(id);
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

        public async Task<List<ListAdvancePaymentVM>> AdvancePayments()
        {
            return await _employeeApiService.AdvancePayments();
        }
    }
}
