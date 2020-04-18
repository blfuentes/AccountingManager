using System;
using System.Collections.Generic;

namespace AccountManager.DAL.EF.Models
{
    public partial class ExpenseModification
    {
        public int ExpenseModificationId { get; set; }
        public decimal Amount { get; set; }
        public DateTime ValidFrom { get; set; }
        public int ExpenseId { get; set; }

        public virtual Expense Expense { get; set; }
    }
}
