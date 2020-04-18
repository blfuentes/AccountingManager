using System;
using System.Collections.Generic;

namespace AccountManager.DAL.EF.Models
{
    public partial class Status
    {
        public int StatusId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}
