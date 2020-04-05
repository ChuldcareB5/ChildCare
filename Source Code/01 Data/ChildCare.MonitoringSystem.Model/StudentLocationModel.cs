using System;
using System.Collections.Generic;
using System.Text;

namespace ChildCare.MonitoringSystem.Model
{
   public class StudentLocationModel
    {
        public int StudentLocationId { get; set; } // StudentLocationId (Primary key)
        public int StudentId { get; set; } // StudentId
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
