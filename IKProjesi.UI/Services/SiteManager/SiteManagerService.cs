using IKProjesi.UI.Models.VMs.SiteManagerVMs;

namespace IKProjesi.UI.Services.SiteManager
{
    public class SiteManagerService : ISiteManagerService
    {
        private readonly ISiteManagerApiService _siteManagerApiService;

        public SiteManagerService(ISiteManagerApiService siteManagerApiService)
        {
            _siteManagerApiService = siteManagerApiService;
        }

        public async Task<SiteManagerSummaryVM> GetSiteManagerSummary(int id)
        {
            return await _siteManagerApiService.GetSiteManagerSummary(id);
        }
        public async Task<SiteManagerUpdateVM> GetSiteManagerById(int id)
        {
            return await _siteManagerApiService.GetSiteManagerById(id);
        }

        public async Task<SiteManagerUpdateVM> GetSiteManagerUpdate(SiteManagerUpdateVM siteManagerUpdateVM)
        {
            if (siteManagerUpdateVM.Image is not null)
                siteManagerUpdateVM.ImageString = await SaveImage(siteManagerUpdateVM.Image);
            
            var siteManager= await _siteManagerApiService.GetSiteManagerUpdate(siteManagerUpdateVM);
            return siteManager;
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
        public async Task<SiteManagerDetailsVM> SiteManagerDetails(int id)
        {
            return await _siteManagerApiService.GetSiteManagerDetails(id);
        }
    }
}
