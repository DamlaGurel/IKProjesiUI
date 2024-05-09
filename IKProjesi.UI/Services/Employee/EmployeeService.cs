using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.Enums;
using IKProjesi.UI.Services.CompanyManager;
using System.IO.Compression;
using IKProjesi.UI.Models.VMs.AdvancePaymentVMs;
using IKProjesi.UI.Models.VMs.ExpenseVMs;
using IKProjesi.UI.Models.VMs.OffDayVMs;
using IKProjesi.UI.Models.VMs.EmployeeVMs;
using IKProjesi.UI.Models.VMs.UserVM;

namespace IKProjesi.UI.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeApiService _employeeApiService;
        int _companyManagerId;

        public EmployeeService(IEmployeeApiService employeeApiService)
        {
            _employeeApiService = employeeApiService;
        }

        #region Employee
        public async Task CreateEmployee(CreateEmployeeVM model)
        {
            TokenVM token = new TokenVM();
            model.CompanyManagerId = AssignUser(token);

            if (model.Image is not null)
            {
                model.ImageString = await SaveImage(model.Image);
            }

            if (model.DepartmentName.HasValue)
            {
                model.DepartmentNumber = (int)model.DepartmentName;
                model.DepartmentName=null;
            }

            await _employeeApiService.CreateEmployee(model);
        }

        public int AssignUser(TokenVM token)
        {
            if (token != null)
            {
                _companyManagerId = Convert.ToInt32(token.UserId);
            }
            return _companyManagerId;
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

        public async Task<SummaryEmployeeVM> GetEmployeeSummary(int id)
        {
            return await _employeeApiService.GetEmployeeSummary(id);
        }

        public async Task<EmployeeDetailsVM> GetEmployeeDetails(int id)
        {
            return await _employeeApiService.GetEmployeeDetails(id);
        }

        public async Task<UpdateEmployeeVM> UpdateEmployee(UpdateEmployeeVM model)
        {
            if (model.Image is not null)
            {
                model.ImageString = await SaveImage(model.Image);
            }
             var employee = await _employeeApiService.UpdateEmployee(model);

            return employee;
        }

        public async Task<UpdateEmployeeVM> GetEmployeeById(int id)
        {
            return await _employeeApiService.GetEmployeeById(id);
        }
        #endregion

        #region Expense
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

        public async Task<List<ListExpenseVM>> ListExpense(int id)
        {
            return await _employeeApiService.ListExpense(id);
        }
        #endregion

        #region Off Day
        public async Task CreateOffDay(CreateOffDayVM model)
        {
            await _employeeApiService.CreateTakeDayOff(model);
        }

        public async Task<List<ListOffDayVM>> ListOffDay(int id)
        {
            return await _employeeApiService.ListOffDay(id);
        }
        #endregion

        #region Advance Payment
        public async Task CreateAdvancePayment(CreateAdvancePaymentVM model)
        {
            model.AdvanceTypeId = (int)model.AdvanceType;
            model.MoneyTypeId = (int)model.MoneyType;
            await _employeeApiService.CreateAdvancePayment(model);
        }

        public async Task<List<ListAdvancePaymentVM>> ListAdvancePayment(int id)
        {
            return await _employeeApiService.ListAdvancePayment(id);
        }
        #endregion
    }
}
