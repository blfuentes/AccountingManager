using System;
using System.Collections.Generic;

namespace AccountManager.DAL.EF.Models
{
    public partial class SalaryModification
    {
        public int SalaryModificationId { get; set; }
        public decimal Amount { get; set; }
        public int SalaryId { get; set; }
        public int SalaryModificationTypeId { get; set; }

        public virtual Salary Salary { get; set; }
        public virtual SalaryModificationType SalaryModificationType { get; set; }
    }
}
