using IKProjesi.UI.Models.Enums;

namespace IKProjesi.UI.Models.VMs.EmployeeVMs
{
    public class ListAdvancePaymentVM
    {
        public AdvanceType AdvanceType { get; set; }
        public double? TotalAdvance { get; set; }
        public MoneyType MoneyType { get; set; }
        public ApprovalType ApprovalType { get; set; }
    }
}
