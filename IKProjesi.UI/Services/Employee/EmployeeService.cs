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

        public async Task CreateEmployee(CreateEmployeeVM model)
        {
            await _employeeApiService.CreateEmployee(model);
        }

        public async Task CreateExpense(CreateExpenseVM model)
        {
            await _employeeApiService.CreateExpense(model);
        }
        public async Task CreateTakeDayOff(CreateOffDayVm model)
        {
            await _employeeApiService.CreateTakeDayOff(model);

        }

        public async Task<List<ListOffDaysVm>> ListTakeDayOff(int id)
        {
            return await _employeeApiService.ListTakeDayOff(id);
        }




    }
}
