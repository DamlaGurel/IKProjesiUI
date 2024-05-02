using IKProjesi.UI.Models.Enums;
using Microsoft.DotNet.Scaffolding.Shared.Project;

namespace IKProjesi.UI.Models.VMs.EmployeeVMs
{
    public class CreateExpenseVM
    {
        public int? EmployeeId { get; set; }
        public ExpenseType? ExpenseType { get; set; }
        public double? TotalExpense { get; set; }
        public MoneyType? MoneyType { get; set; }
        public ApprovalType? ApprovalType { get; set; }
        public DateTime? ResponseDate { get; set; }
        public DateTime? RequestDate { get; set; }
        public IFormFile File { get; set; }
    }
}
