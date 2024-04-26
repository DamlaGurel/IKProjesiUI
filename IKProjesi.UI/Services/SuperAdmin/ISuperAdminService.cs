using IKProjesi.UI.Models.VMs.SiteManagerVMs;

namespace IKProjesi.UI.Services.SuperAdmin
{
    public interface ISuperAdminService
    {
        Task<CreateSiteManagerVM> CreateSiteManager(CreateSiteManagerVM createSiteManager);
    }
}
