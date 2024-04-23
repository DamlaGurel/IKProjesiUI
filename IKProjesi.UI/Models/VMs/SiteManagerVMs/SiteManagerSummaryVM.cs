using IKProjesi.UI.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace IKProjesi.UI.Models.VMs.SiteManagerVMs
{
    public class SiteManagerSummaryVM
    {
        public string FirstName { get; set; }
        public string? SecondName { get; set; }

        public string LastName { get; set; }
        public string? SecondLastName { get; set; }
        public string? ImagePath { get; set; }

        [NotMapped]
        public IFormFile ProfilePicture { get; set; }
        public string Email { get; set; }
        public Job JobName { get; set; }
        public Department DepartmentName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
