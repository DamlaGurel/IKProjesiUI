using IKProjesi.UI.Models.Enums;

namespace IKProjesi.UI.Models.VMs.SiteManagerVMs
{
    public class CreateSiteManagerVM
    {
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string LastName { get; set; }
        public string? SecondLastName { get; set; }
        public string Password { get; set; }
        //public string? ImagePath { get; set; }
        public string? UserName { get; set; }
        //[NotMapped]
        //public IFormFile? ProfilePicture { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public string? IdentityNumber { get; set; }
        public DateTime? StartDateOfWork { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime CreatedDate => DateTime.Now;
        public Status Status => Status.Active;
    }
}
