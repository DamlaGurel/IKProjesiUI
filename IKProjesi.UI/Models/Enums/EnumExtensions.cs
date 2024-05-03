using IKProjesi.UI.Models.VMs.EmployeeVMs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Security.Policy;

namespace IKProjesi.UI.Models.Enums
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }

        public static void GetEnumValue(CreateExpenseVM createExpense)
        {
            if (createExpense.ExpenseType == ExpenseType.Transportation)
                createExpense.ExpenseTypeId = 1;
            else if (createExpense.ExpenseType == ExpenseType.Accommodation)
                createExpense.ExpenseTypeId = 2;
            else if (createExpense.ExpenseType == ExpenseType.Food)
                createExpense.ExpenseTypeId = 3;
            else if (createExpense.ExpenseType == ExpenseType.Other)
                createExpense.ExpenseTypeId = 4;

            if (createExpense.MoneyType == MoneyType.TRY)
                createExpense.MoneyTypeId = 1;
            else if (createExpense.MoneyType == MoneyType.USD)
                createExpense.MoneyTypeId = 2;
            else if (createExpense.MoneyType == MoneyType.EUR)
                createExpense.MoneyTypeId = 3;
            else if (createExpense.MoneyType == MoneyType.GBP)
                createExpense.MoneyTypeId = 4;
            else if (createExpense.MoneyType == MoneyType.JPY)
                createExpense.MoneyTypeId = 5;
            else if (createExpense.MoneyType == MoneyType.CHF)
                createExpense.MoneyTypeId = 6;
            else if (createExpense.MoneyType == MoneyType.AUD)
                createExpense.MoneyTypeId = 7;
            else if (createExpense.MoneyType == MoneyType.CAD)
                createExpense.MoneyTypeId = 8;
            else if (createExpense.MoneyType == MoneyType.NZD)
                createExpense.MoneyTypeId = 9;
            else if (createExpense.MoneyType == MoneyType.CNY)
                createExpense.MoneyTypeId = 10;
            else if (createExpense.MoneyType == MoneyType.BRL)
                createExpense.MoneyTypeId = 11;
        } 
    }
}
