namespace IKProjesi.UI.Models.VMs.SiteManagerVMs
{
    public class SiteManagerUpdateVM
    {
        public int Id { get; set; }
        public IFormFile Image { get; set; }
        public string? ImageString { get; set; }
        public byte[]? ImageBytes { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
