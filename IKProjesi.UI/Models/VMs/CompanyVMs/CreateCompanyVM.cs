using IKProjesi.UI.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace IKProjesi.UI.Models.VMs.CompanyVMs
{
    public class CreateCompanyVM
    {
        public string CompanyName { get; set; }
        public string CompanyTitle { get; set; }
        public string MersisNumber { get; set; }
        public string CompanyTaxNumber { get; set; }
        public string CompanyTaxOffice { get; set; }
        public IFormFile? Logo { get; set; }
        public string? LogoString { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int EmployeeNumber { get; set; }
        [CompanyDateTimeValidation]
        public DateTime FoundationYear { get; set; }
        [ContractDateValidation]
        public DateTime StartContractDate { get; set; }
        public DateTime EndContractDate { get; set; }

        //public Status Status => Status.Active;

        // public List<ListCompanyManagerDto>? CompanyManagers { get; set; }
    }
}
