using System;
using System.Collections.Generic;

namespace AccountManager.DAL.EF.Models
{
    public partial class Balance
    {
        public int BalanceId { get; set; }
        public decimal InitialAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public decimal? Variation { get; set; }
        public double PercentVariation { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DateClosed { get; set; }
    }
}
