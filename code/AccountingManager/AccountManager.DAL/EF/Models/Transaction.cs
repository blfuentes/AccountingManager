using System;
using System.Collections.Generic;

namespace AccountManager.DAL.EF.Models
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime AnnotationDate { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public int OriginAccountId { get; set; }
        public int? TargetAccountId { get; set; }
        public int? MovementId { get; set; }
        public int TransactionTypeId { get; set; }

        public virtual Movement Movement { get; set; }
        public virtual Account OriginAccount { get; set; }
        public virtual Account TargetAccount { get; set; }
        public virtual TransactionType TransactionType { get; set; }
    }
}
