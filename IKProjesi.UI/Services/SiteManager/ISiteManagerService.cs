using IKProjesi.UI.Models.VMs.SiteManagerVMs;

namespace IKProjesi.UI.Services.SiteManager
{
    public interface ISiteManagerService
    {
        Task<SiteManagerSummaryVM> GetSiteManagerSummary(int id);
        Task<SiteManagerDetailsVM> SiteManagerDetails(int id);
        Task<SiteManagerUpdateVM> GetSiteManagerById(int id);
        Task<SiteManagerUpdateVM> GetSiteManagerUpdate(SiteManagerUpdateVM siteManagerUpdateVM);
    }
}
