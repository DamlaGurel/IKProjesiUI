using IKProjesi.UI.Models.Enums;

namespace IKProjesi.UI.Models.VMs.EmployeeVMs
{
    public class CreateAdvancePaymentVM
    {
        //public int? Id { get; set; }
        public int? EmployeeId { get; set; }
        public AdvanceType? AdvanceType { get; set; }
        public int AdvanceTypeId { get; set; }
        public double? TotalAdvance { get; set; }
        public double? Salary { get; set; }
        public MoneyType? MoneyType { get; set; }
        public int MoneyTypeId { get; set; }
        public ApprovalType? ApprovalType { get; set; }
        public DateTime? ResponseTime { get; set; }
        public DateTime? RequestDate { get; set; }
        public string? Description { get; set; }
    }
}
