using IKProjesi.UI.Models.VMs.AdvancePaymentVMs;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.ExpenseVMs;
using IKProjesi.UI.Models.VMs.OffDayVMs;

namespace IKProjesi.UI.Services.CompanyManager
{
    public class CompanyManagerService : ICompanyManagerService
    {
        private readonly ICompanyManagerApiService _companyManagerApiService;

        public CompanyManagerService(ICompanyManagerApiService companyManagerApiService)
        {
            _companyManagerApiService = companyManagerApiService;
        }

        #region Image
        private async Task<string> SaveImage(IFormFile image)
        {
            var imageFile = image;
            byte[] imageBytes = null;

            using (var memoryStream = new MemoryStream())
            {
                await imageFile.CopyToAsync(memoryStream);

                if (memoryStream.Length < 2097152)
                    imageBytes = memoryStream.ToArray();
                else
                    return null;
            }

            string imageString = Convert.ToBase64String(imageBytes);
            return imageString;
        }
        #endregion

        #region CompanyManager
        public async Task CreateCompanyManager(CreateCompanyManagerVM model)
        {
            if (model.Image is not null)
                model.ImageString = await SaveImage(model.Image);

            await _companyManagerApiService.CreateCompanyManager(model);
        }

        //public async Task<CreateCompanyManagerVM> GetCompanyManagerById(int id)
        //{
        //    return await _companyManagerApiService.GetCompanyManagerById(id);            
        //}

        public async Task<List<ListCompanyManagerVM>> GetCompanyManagers()
        {
            return await _companyManagerApiService.GetCompanyManagers();
        }

        public async Task<SummaryCompanyManagerVM> GetCompanyManagerSummary(int id)
        {
            return await _companyManagerApiService.GetCompanyManagerSummary(id);
        }

        public async Task<UpdateCompanyManagerVM> GetCompanyManagerUpdate(UpdateCompanyManagerVM updateCompanyManager)
        {
            if (updateCompanyManager.Image is not null)
            {
                updateCompanyManager.ImageString = await SaveImage(updateCompanyManager.Image);
            }
            var companyManager= await _companyManagerApiService.GetCompanyManagerUpdate(updateCompanyManager);

            return companyManager;
        }

        public async Task<DetailsCompanyManagerVM> GetCompanyManagerDetails(int id)
        {
            return await _companyManagerApiService.GetCompanyManagerDetails(id);
        }

        public async Task<UpdateCompanyManagerVM> GetCompanyManagerById(int id)
        {
            return await _companyManagerApiService.GetCompanyManagerById(id);
        }
        #endregion

        #region OffDay
        public async Task<List<ListWaitingApprovalForOffDayVM>> ListApprovalForOffDay()
        {
            return await _companyManagerApiService.ListApprovalForOffDay();
        }

        public async Task GetApprovalForOffDay(UpdateOffDayVM model)
        {
            await _companyManagerApiService.ApprovalForOffDay(model);

        }

        public async Task<UpdateOffDayVM> GetApprovalForOffDay(int id)
        {
            return await _companyManagerApiService.GetApprovalForOffDay(id);
        }
        #endregion


        #region Expense
        public async Task<List<ListWaitingApprovalForExpenseVM>> ListApprovalForExpense()

        {
            return await _companyManagerApiService.ListApprovalForExpense();

        }

        public async Task GetApprovalForExpense(UpdateExpenseVM model)
        {
            await _companyManagerApiService.ApprovalForExpense(model);

        }

        public async Task<UpdateExpenseVM> GetApprovalForExpense(int id)
        {
            return await _companyManagerApiService.GetApprovalForExpense(id);

        }
        #endregion

        #region Advance Payment
        public async Task<List<ListWaitingApprovalForAdvancePaymentVM>> ListApprovalForAdvancePayment()

        {
            return await _companyManagerApiService.ListApprovalForAdvancePayment();

        }

        public async Task GetApprovalForAdvancePayment(UpdateAdvancePaymentVM model)
        {
            await _companyManagerApiService.ApprovalForAdvancePayment(model);

        }

        public async Task<UpdateAdvancePaymentVM> GetApprovalForAdvancePayment(int id)
        {
            return await _companyManagerApiService.GetApprovalForAdvancePayment(id);

        }
        #endregion
    }
}

