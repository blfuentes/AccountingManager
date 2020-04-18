using System;
using System.Collections.Generic;

namespace AccountManager.DAL.EF.Models
{
    public partial class Target
    {
        public Target()
        {
            Present = new HashSet<Present>();
        }

        public int TargetId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Present> Present { get; set; }
    }
}
