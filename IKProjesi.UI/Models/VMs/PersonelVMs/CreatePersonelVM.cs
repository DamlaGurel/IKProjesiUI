using IKProjesi.UI.Models.Enums;

namespace IKProjesi.UI.Models.VMs.PersonelVMs
{
    public class CreatePersonelVM
    {
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string LastName { get; set; }
        public string? SecondLastName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        //public string ImageString { get; set; }
        //public byte[] ImageBytes { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public string? IdentityNumber { get; set; }
        public DateTime? StartDateOfWork { get; set; }
        public string? DepartmentName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string CompanyName { get; set; }
    }
}
