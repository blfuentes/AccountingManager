using System;
using System.Collections.Generic;

namespace AccountManager.DAL.EF.Models
{
    public partial class ExpenseFamily
    {
        public ExpenseFamily()
        {
            ExpenseType = new HashSet<ExpenseType>();
        }

        public int ExpenseFamilyId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ExpenseType> ExpenseType { get; set; }
    }
}
