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

        public async Task<EmployeeDetailsVm> GetEmployeeDetails(int id)
        {
            return await _employeeApiService.GetEmployeeDetails(id);
        }

        public async Task UpdateEmployee(UpdateEmployeeVm model)
        {
            if (model.Image is not null)
            {
                model.ImageString = await SaveImage(model.Image);
            }
            await _employeeApiService.UpdateEmployee(model);
        }

        public async Task<UpdateEmployeeVm> GetEmployeeById(int id)
        {
            return await _employeeApiService.GetEmployeeById(id);
        }
    }
}
