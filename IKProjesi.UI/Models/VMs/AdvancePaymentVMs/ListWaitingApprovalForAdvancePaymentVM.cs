using System;
using IKProjesi.UI.Models.Enums;

namespace IKProjesi.UI.Models.VMs.AdvancePaymentVMs
{
	public class ListWaitingApprovalForAdvancePaymentVM
	{
        public int? Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? AdvanceType { get; set; }
        public double? TotalAdvance { get; set; }
        public int? MoneyType { get; set; }
        public ApprovalType? ApprovalType { get; set; }
        public DateTime? ResponseTime { get; set; }
        public DateTime? RequestDate { get; set; }
        public string? Description { get; set; }
        public string? EmployeeFullName { get; set; }
    }
}

