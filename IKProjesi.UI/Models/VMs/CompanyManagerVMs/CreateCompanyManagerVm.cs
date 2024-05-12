using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using IKProjesi.UI.Extensions;
using IKProjesi.UI.Extensions.Validation;
using IKProjesi.UI.Models.Enums;
using IKProjesi.UI.Models.VMs.CompanyVMs;

namespace IKProjesi.UI.Models.VMs.CompanyManagerVMs
{
    public class CreateCompanyManagerVM
    {
        [Required(ErrorMessage = "Ad alanı boş bırakılamaz.")]
        [StringLength(15, ErrorMessage = "En az 3, en çok 15 karakterden oluşmalıdır.", MinimumLength = 3)]
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        [Required(ErrorMessage = "Soyad alanı boş bırakılamaz.")]
        [StringLength(30, ErrorMessage = "En az 3, en çok 30 karakterden oluşmalıdır.", MinimumLength = 3)]
        public string? LastName { get; set; }
        public string? SecondLastName { get; set; }
        public string PersonalEmail { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        [IdentificationNumberValidation]
        public string? IdentityNumber { get; set; }
        [BirthDateValidation]
        public DateTime? StartDateOfWork { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public int CompanyId { get; set; }
        //public DateTime CreatedDate => DateTime.Now;
        //public Status Status => Status.Active;
        public IFormFile? Image { get; set; }
        public string? ImageString { get; set; }

        public double? Payment { get; set; }
    }
}

