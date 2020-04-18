using System;
using System.Collections.Generic;

namespace AccountManager.DAL.EF.Models
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            Transaction = new HashSet<Transaction>();
        }

        public int TransactionTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
