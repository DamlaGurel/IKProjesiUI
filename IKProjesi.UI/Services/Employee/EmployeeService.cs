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
            if (model.Image is not null)
            {
                model.ImageString = await SaveImage(model.Image);
            }

            if (model.DepartmentName.HasValue)
            {
                // Cast the enum value to int and assign it to the corresponding property
                model.DepartmentNumber = (int)model.DepartmentName;
            }

            await _employeeApiService.CreateEmployee(model);
        }

        public async Task<string?> SaveImage(IFormFile image)
        {
            var imageFile = image;

            byte[] imageBytes = null;

            using (var memoryStream = new MemoryStream())
            {
                await imageFile.CopyToAsync(memoryStream);

                if (memoryStream.Length < 2097152)
                {
                    imageBytes = memoryStream.ToArray();
                }
                else
                {
                   return null;
                }
            }

            string imageString = Convert.ToBase64String(imageBytes);
            return imageString;
        }

        public async Task<SummaryEmployeeVm> GetEmployeeSummary(int id)
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
        public async Task CreateTakeDayOff(CreateOffDayVM model)
        {
            await _employeeApiService.CreateTakeDayOff(model);

        }

        public async Task<List<ListOffDaysVM>> ListTakeDayOff(int id)
        {
            return await _employeeApiService.ListTakeDayOff(id);
        }





        public async Task<UpdateEmployeeVm> UpdateEmployee(UpdateEmployeeVm model)
        {
            if (model.Image is not null)
            {
                model.ImageString = await SaveImage(model.Image);
            }
            await _employeeApiService.UpdateEmployee(model);

            return model;
        }

        public async Task<UpdateEmployeeVm> GetEmployeeById(int id)
        {
            return await _employeeApiService.GetEmployeeById(id);
        }

        public async Task<List<ListAdvancePaymentVM>> AdvancePayments()
        {
            return await _employeeApiService.AdvancePayments();
        }
    }
}
