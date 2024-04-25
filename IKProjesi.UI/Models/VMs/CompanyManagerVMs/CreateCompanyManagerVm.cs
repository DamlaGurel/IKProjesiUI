using System;
using System.Net.NetworkInformation;
using IKProjesi.UI.Models.Enums;
using IKProjesi.UI.Models.VMs.CompanyVMs;

namespace IKProjesi.UI.Models.VMs.CompanyManagerVMs
{
    public class CreateCompanyManagerVm
    {
       
        public string FirstName { get; set; }

        public string? SecondName { get; set; }

       
        public string? LastName { get; set; }

       
        public string? SecondLastName { get; set; }

        //[Display(Name = "Profil Fotoğrafı")]
        // [PictureFileExtension]
        //public IFormFile? ProfilePicture { get; set; }

        public string? Password { get; set; }
      
        public DateTime? BirthDate { get; set; }
        


        
        public string? BirthPlace { get; set; }

        //[Required(ErrorMessage = "TC Kimlik numarası girilmesi zorunludur.")]
        //[Display(Name = "TC Kimlik Numarası")]
        //[IdentificationNumberValidation(ErrorMessage = "Lütfen geçerli bir TC Kimlik numarası giriniz.")]
        public string? IdentityNumber { get; set; }

        //[Display(Name = "İşe Başlangıç Tarihi")]
        public DateTime? StartDateOfWork { get; set; }

        //[Display(Name = "Meslek")]
        public string? JobName { get; set; }

        //[Display(Name = "Departman Adı")]
        public string? DepartmentName { get; set; }

        //[Display(Name = "Adres")]
        public string? Address { get; set; }

        //[Display(Name = "Telefon Numarası")]
        public string? PhoneNumber { get; set; }

        //public string Email { get; set; }

        //public DateTime CreatedDate => DateTime.Now;

        //public Status Status => Status.Active;

        // //Company Seçim 
        // public int? CompanyId { get; set; }

        public string CompanyName { get; set; }
    }
}

