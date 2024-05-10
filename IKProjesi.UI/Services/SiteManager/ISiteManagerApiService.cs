using IKProjesi.UI.Models.VMs.SiteManagerVMs;
using Refit;

namespace IKProjesi.UI.Services.SiteManager
{
    public interface ISiteManagerApiService
    {
        [Get("/api/SiteManager/SiteManagerSummary/{id}")]
        Task<SiteManagerSummaryVM> GetSiteManagerSummary(int id);

        [Get("/api/SiteManager/SiteManagerDetails/{id}")]
        Task<SiteManagerDetailsVM> GetSiteManagerDetails(int id);

        [Put("/api/SiteManager/UpdateSiteManager")]
        Task<SiteManagerUpdateVM> GetSiteManagerUpdate(SiteManagerUpdateVM siteManagerUpdateVM);

        [Get("/api/SiteManager/GetSiteManagerById/{id}")]
        Task<SiteManagerUpdateVM> GetSiteManagerById(int id);
    }
}
