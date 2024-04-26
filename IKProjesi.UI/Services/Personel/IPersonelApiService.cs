using IKProjesi.UI.Models.VMs.CompanyVMs;
using IKProjesi.UI.Models.VMs.PersonelVMs;
using Refit;

namespace IKProjesi.UI.Services.Personel
{
    public interface IPersonelApiService
    {
        [Post("/api/CompanyManager/CreatePersonel")]
        Task CreatePersonel(CreatePersonelVM model);
    }
}
