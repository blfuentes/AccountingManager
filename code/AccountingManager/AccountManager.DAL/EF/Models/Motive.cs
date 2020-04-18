using System;
using System.Collections.Generic;

namespace AccountManager.DAL.EF.Models
{
    public partial class Motive
    {
        public Motive()
        {
            Present = new HashSet<Present>();
        }

        public int MotiveId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Present> Present { get; set; }
    }
}
