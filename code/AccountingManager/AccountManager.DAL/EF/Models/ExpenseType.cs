using System;
using System.Collections.Generic;

namespace AccountManager.DAL.EF.Models
{
    public partial class ExpenseType
    {
        public ExpenseType()
        {
            Expense = new HashSet<Expense>();
        }

        public int ExpenseTypeId { get; set; }
        public string Name { get; set; }
        public int ExpenseFamilyId { get; set; }

        public virtual ExpenseFamily ExpenseFamily { get; set; }
        public virtual ICollection<Expense> Expense { get; set; }
    }
}
