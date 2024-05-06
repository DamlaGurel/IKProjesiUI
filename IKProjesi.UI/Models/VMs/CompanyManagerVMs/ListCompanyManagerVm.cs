using System;
namespace IKProjesi.UI.Models.VMs.CompanyManagerVMs
{
	public class ListCompanyManagerVM
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}

