using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using IKProjesi.UI.Models.Enums;
using IKProjesi.UI.Models.VMs.CompanyVMs;

namespace IKProjesi.UI.Models.VMs.CompanyManagerVMs
{
    public class CreateCompanyManagerVm
    {

        [Required(ErrorMessage ="Lütfen adınızı giriniz.")]
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        [Required(ErrorMessage = "Lütfen soyadınızı giriniz.")]
        public string? LastName { get; set; }
        public string? SecondLastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public string? IdentityNumber { get; set; }
        public DateTime? StartDateOfWork { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public int CompanyId { get; set; }
        public DateTime CreatedDate => DateTime.Now;
        public Status Status => Status.Active;
        public IFormFile? Image { get; set; }
        public string? ImageString { get; set; }
    }
}

