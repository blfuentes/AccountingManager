using System;
using System.Collections.Generic;

namespace AccountManager.DAL.EF.Models
{
    public partial class Payment
    {
        public Payment()
        {
            ForecastDetail = new HashSet<ForecastDetail>();
        }

        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime? ValidTo { get; set; }

        public virtual ICollection<ForecastDetail> ForecastDetail { get; set; }
    }
}
