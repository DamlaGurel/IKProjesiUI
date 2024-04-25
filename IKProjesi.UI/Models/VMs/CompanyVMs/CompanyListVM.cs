namespace IKProjesi.UI.Models.VMs.CompanyVMs
{
    public class CompanyListVM
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTitle { get; set; }
        public string? LogoString { get; set; }
        public byte[]? LogoBytes { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
