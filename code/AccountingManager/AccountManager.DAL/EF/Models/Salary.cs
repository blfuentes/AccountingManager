using System;
using System.Collections.Generic;

namespace AccountManager.DAL.EF.Models
{
    public partial class Salary
    {
        public Salary()
        {
            SalaryModification = new HashSet<SalaryModification>();
        }

        public int SalaryId { get; set; }
        public decimal BasePayment { get; set; }
        public decimal? NetPayment { get; set; }
        public DateTime Date { get; set; }
        public DateTime? PaymentDate { get; set; }

        public virtual ICollection<SalaryModification> SalaryModification { get; set; }
    }
}
