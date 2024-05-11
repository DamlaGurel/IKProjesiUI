using System;
using IKProjesi.UI.Models.Enums;

namespace IKProjesi.UI.Models.VMs.ExpenseVMs
{
	public class ListExpenseVM
	{
        public ExpenseType? ExpenseType { get; set; }
        public MoneyType? MoneyType { get; set; }
        public ApprovalType? ApprovalType { get; set; }
        public double? TotalExpense { get; set; }
    }
}

