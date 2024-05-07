using IKProjesi.UI.Models.Enums;

namespace IKProjesi.UI.Models.VMs.EmployeeVMs
{
    public class ListExpenseVM
    {
        public ExpenseType? ExpenseType { get; set; }
        public MoneyType? MoneyType { get; set; }
        public double? TotalExpense { get; set; }
    }
}
