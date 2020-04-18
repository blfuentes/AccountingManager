using System;
using System.Collections.Generic;

namespace AccountManager.DAL.EF.Models
{
    public partial class Present
    {
        public int PresentId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public bool IsReturned { get; set; }
        public int MotiveId { get; set; }
        public int TargetId { get; set; }

        public virtual Motive Motive { get; set; }
        public virtual Target Target { get; set; }
    }
}
