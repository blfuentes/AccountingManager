using System;
using System.Collections.Generic;

namespace AccountManager.DAL.EF.Models
{
    public partial class Account
    {
        public Account()
        {
            Status = new HashSet<Status>();
            TransactionOriginAccount = new HashSet<Transaction>();
            TransactionTargetAccount = new HashSet<Transaction>();
        }

        public int AccountId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Status> Status { get; set; }
        public virtual ICollection<Transaction> TransactionOriginAccount { get; set; }
        public virtual ICollection<Transaction> TransactionTargetAccount { get; set; }
    }
}
