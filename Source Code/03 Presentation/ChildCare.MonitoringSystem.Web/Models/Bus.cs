using System;
using System.Collections.Generic;

namespace ChildCare.MonitoringSystem.Web.Models
{
    public partial class Bus
    {
        public Bus()
        {
            BusSchedule = new HashSet<BusSchedule>();
        }

        public int BusId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<BusSchedule> BusSchedule { get; set; }
    }
}
