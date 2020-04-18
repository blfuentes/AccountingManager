using System;
using System.Collections.Generic;

namespace AccountManager.DAL.EF.Models
{
    public partial class SalaryModificationType
    {
        public SalaryModificationType()
        {
            SalaryModification = new HashSet<SalaryModification>();
        }

        public int SalaryModificationTypeId { get; set; }
        public string Name { get; set; }
        public decimal DefaultValue { get; set; }

        public virtual ICollection<SalaryModification> SalaryModification { get; set; }
    }
}
