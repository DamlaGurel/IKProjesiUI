using IKProjesi.UI.Models.VMs.SiteManagerVMs;

namespace IKProjesi.UI.Services.SuperAdmin
{
    public interface ISuperAdminService
    {
        Task CreateSiteManager(CreateSiteManagerVM createSiteManager);
    }
}
