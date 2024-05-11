namespace IKProjesi.UI.Models.VMs.UserVM
{
    public class TokenVM
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string? Token { get; set; }
        public DateTime? Expiration { get; set; }
        public string? Role { get; set; }
    }
}
