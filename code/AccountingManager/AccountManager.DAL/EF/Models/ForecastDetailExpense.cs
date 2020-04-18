using System;
using System.Collections.Generic;

namespace AccountManager.DAL.EF.Models
{
    public partial class ForecastDetailExpense
    {
        public int ForecastDetailId { get; set; }
        public int ExpenseId { get; set; }

        public virtual Expense Expense { get; set; }
        public virtual ForecastDetail ForecastDetail { get; set; }
    }
}
