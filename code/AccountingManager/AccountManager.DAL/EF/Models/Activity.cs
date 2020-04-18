using System;
using System.Collections.Generic;

namespace AccountManager.DAL.EF.Models
{
    public partial class Activity
    {
        public Activity()
        {
            Movement = new HashSet<Movement>();
        }

        public int ActivityId { get; set; }
        public string Name { get; set; }
        public bool Ourense { get; set; }
        public int ActivityTypeId { get; set; }

        public virtual ActivityType ActivityType { get; set; }
        public virtual ICollection<Movement> Movement { get; set; }
    }
}
