using System;
using System.Collections.Generic;

namespace AccountManager.DAL.EF.Models
{
    public partial class ActivityType
    {
        public ActivityType()
        {
            Activity = new HashSet<Activity>();
        }

        public int ActivityTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Activity> Activity { get; set; }
    }
}
