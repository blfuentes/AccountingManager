using System;
using System.Collections.Generic;

namespace AccountManager.DAL.EF.Models
{
    public partial class ForecastDetail
    {
        public ForecastDetail()
        {
            ForecastDetailExpense = new HashSet<ForecastDetailExpense>();
        }

        public int ForecastDetailId { get; set; }
        public int Month { get; set; }
        public decimal InitialBalance { get; set; }
        public decimal? ExtraExpenses { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal? CarAmount { get; set; }
        public decimal? FlightAmount { get; set; }
        public string Comments { get; set; }
        public decimal Estimation { get; set; }
        public decimal BalanceEstimation { get; set; }
        public decimal Adjustment { get; set; }
        public decimal FinalAmount { get; set; }
        public decimal FinalBalance { get; set; }
        public double SavingsPercent { get; set; }
        public bool IsClosed { get; set; }
        public int PaymentId { get; set; }

        public virtual Payment Payment { get; set; }
        public virtual ICollection<ForecastDetailExpense> ForecastDetailExpense { get; set; }
    }
}
