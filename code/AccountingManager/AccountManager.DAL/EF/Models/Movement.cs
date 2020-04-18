using System;
using System.Collections.Generic;

namespace AccountManager.DAL.EF.Models
{
    public partial class Movement
    {
        public Movement()
        {
            Transaction = new HashSet<Transaction>();
        }

        public int MovementId { get; set; }
        public bool IsCredit { get; set; }
        public int ActivityId { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
