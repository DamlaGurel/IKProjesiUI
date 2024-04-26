using IKProjesi.UI.Models.VMs.PersonelVMs;

namespace IKProjesi.UI.Services.Personel
{
    public interface IPersonelService
    {
        Task CreatePersonel(CreatePersonelVM model);
    }
}
