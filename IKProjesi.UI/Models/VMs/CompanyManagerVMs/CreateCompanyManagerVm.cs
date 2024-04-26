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
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public string? IdentityNumber { get; set; }
        public DateTime? StartDateOfWork { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CompanyName { get; set; }
        public Job? JobName { get; set; }
        public Department? DepartmentName { get; set; }
        public DateTime CreatedDate => DateTime.Now;
        public Status Status => Status.Active;
        //public string Email { get; set; }

        //public DateTime CreatedDate => DateTime.Now;

        //public Status Status => Status.Active;

        // //Company Seçim 
        // public int? CompanyId { get; set; }

        //public string CompanyName { get; set; }
    }
}

