using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManager.DAL.DTO
{
    public class BalanceDTO
    {
        public int BalanceID { get; set; }
        public int MonthSort { get; set; }
        public string MonthName { get; set; }
        public decimal InitialAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public decimal Variation { get; set; }
        public decimal PercentVariation { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DateClosed { get; set; }
    }
}
