using IKProjesi.UI.Models.VMs.SiteManagerVMs;
using IKProjesi.UI.Services.SiteManager;
using IKProjesi.UI.Services.User;

namespace IKProjesi.UI.Services.SuperAdmin
{
    public class SuperAdminService : ISuperAdminService
    {
        private readonly ISuperAdminApiService _superAdminApiService;

        public SuperAdminService(ISuperAdminApiService superAdminApiService)
        {
            _superAdminApiService = superAdminApiService;
        }

        public async Task CreateSiteManager(CreateSiteManagerVM createSiteManager)
        {
            createSiteManager.DepartmentId = (int)createSiteManager.Department;
            if (createSiteManager.Image is not null)
                createSiteManager.ImageString = await SaveImage(createSiteManager.Image);

            await _superAdminApiService.CreateSiteManagerVM(createSiteManager);
        }


        public async Task<List<SiteManagerDetailsVM>> GetSiteManagers()
        {
            return await _superAdminApiService.SiteManagerDetails();
        }
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
    }
}
