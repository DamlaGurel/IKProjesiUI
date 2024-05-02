using IKProjesi.UI.Models.VMs.PersonelVMs;

namespace IKProjesi.UI.Services.Personel
{
    public class PersonelService:IPersonelService
    {
        private readonly IPersonelApiService _personelApiService;

        public PersonelService(IPersonelApiService personelApiService)
        {
            _personelApiService = personelApiService;
        }

        public async Task CreatePersonel(CreatePersonelVM model)
        {
            await _personelApiService.CreatePersonel(model);
        }

        public async Task CreateTakeOffDay(CreateDaysOffVm model)
        {
            await _personelApiService.CreateTakeOffDay(model);

        }
    }
}
