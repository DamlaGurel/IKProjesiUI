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

        public async Task<CreateSiteManagerVM> CreateSiteManager(CreateSiteManagerVM createSiteManager)
        {
            return await _siteManagerApiService.CreateSiteManagerVM(createSiteManager);
        }

        public async Task<SiteManagerSummaryVM> GetSiteManagerSummary(int id)
        {
            return await _siteManagerApiService.GetSiteManagerSummary(id);
        }

        public async Task GetSiteManagerUpdate(SiteManagerUpdateVM siteManagerUpdateVM)
        {
            await _siteManagerApiService.GetSiteManagerUpdate(siteManagerUpdateVM);
        }

        public async Task<SiteManagerDetailsVM> SiteManagerDetails(int id)
        {
            return await _siteManagerApiService.GetSiteManagerDetails(id);
        }
    }
}
