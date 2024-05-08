using IKProjesi.UI.Models.Enums;
using Microsoft.DotNet.Scaffolding.Shared.Project;

namespace IKProjesi.UI.Models.VMs.ExpenseVMs
{
    public class CreateExpenseVM
    {
        public ExpenseType? ExpenseType { get; set; }
        public int ExpenseTypeId { get; set; }
        public MoneyType? MoneyType { get; set; }
        public int MoneyTypeId { get; set; }
        public double? TotalExpense { get; set; }
        public IFormFile? File { get; set; }
        public byte[]? FileByteArray { get; set; }

    }
}
