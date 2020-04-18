using System;
using System.Collections.Generic;

namespace AccountManager.DAL.EF.Models
{
    public partial class Expense
    {
        public Expense()
        {
            ExpenseModification = new HashSet<ExpenseModification>();
            ForecastDetailExpense = new HashSet<ForecastDetailExpense>();
        }

        public int ExpenseId { get; set; }
        public decimal Amount { get; set; }
        public int ExpenseTypeId { get; set; }

        public virtual ExpenseType ExpenseType { get; set; }
        public virtual ICollection<ExpenseModification> ExpenseModification { get; set; }
        public virtual ICollection<ForecastDetailExpense> ForecastDetailExpense { get; set; }
    }
}
