using IKProjesi.UI.Services.CompanyManager;
using System.Drawing;
using System.Net.NetworkInformation;

namespace IKProjesi.UI.Models.VMs.CompanyVMs
{
    public class CompanyDetailsVM
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTitle { get; set; }
        public string MersisNumber { get; set; }
        public string CompanyTaxNumber { get; set; }
        public string CompanyTaxOffice { get; set; }
        public string LogoString { get; set; }
        public byte[] LogoBytes{ get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int EmployeeNumber { get; set; }
        public DateTime FoundationYear { get; set; }
        public DateTime StartContractDate { get; set; }
        public DateTime EndContractDate { get; set; }

        //public List<CompanyManager>? CompanyManagers { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        //public Status Status { get; set; }
    }
}
