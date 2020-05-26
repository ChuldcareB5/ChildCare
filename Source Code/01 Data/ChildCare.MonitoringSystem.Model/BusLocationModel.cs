using System;
using System.Collections.Generic;
using System.Text;

namespace ChildCare.MonitoringSystem.Model
{
    public class BusLocationModel
    {
        public int BusLocationId { get; set; } // BusLocationId (Primary key)
        public int BusId { get; set; } // BusId
        public int BusScheduleId { get; set; } // BusScheduleId
        public System.DateTime LocationTime { get; set; } // LocationTime
        public double Longitute { get; set; } // Longitute
        public double Latitude { get; set; } // Latitude
        public int CreatedBy { get; set; } // CreatedBy
        public System.DateTime CreatedOn { get; set; } // CreatedOn
        public int UpdatedBy { get; set; } // UpdatedBy
        public System.DateTime UpdatedOn { get; set; } // UpdatedOn
        public bool IsDeleted { get; set; } // IsDeleted
    }
}
