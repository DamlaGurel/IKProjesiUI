using IKProjesi.UI.Extensions;
using IKProjesi.UI.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace IKProjesi.UI.Models.VMs.EmployeeVMs
{
    public class CreateEmployeeVM
    {
        [Required(ErrorMessage = "Ad alanı boş bırakılamaz.")]
        [StringLength(15, ErrorMessage = "En az 3, en çok 15 karakterden oluşmalıdır.", MinimumLength = 3)]
        public string FirstName { get; set; }

        public string? SecondName { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş bırakılamaz.")]
        [StringLength(30, ErrorMessage = "En az 3, en çok 30 karakterden oluşmalıdır.", MinimumLength = 3)]
        public string LastName { get; set; }

        public string? SecondLastName { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageString { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        [IdentificationNumberValidation]
        public string? IdentityNumber { get; set; }
        [BirthDateValidation]
        public DateTime? StartDateOfWork { get; set; }
        public Department? DepartmentName { get; set; }
        public int? DepartmentNumber { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        //public string CompanyName { get; set; }
    }
}
