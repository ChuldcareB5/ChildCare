using System;
using System.Collections.Generic;

namespace ChildCare.MonitoringSystem.Web.Models
{
    public partial class BusSchedule
    {
        public BusSchedule()
        {
            StudentBusSchedule = new HashSet<StudentBusSchedule>();
        }

        public int BusScheduleId { get; set; }
        public string BusScheduleDriverName { get; set; }
        public string ToBusSchedule { get; set; }
        public string FromBusSchedule { get; set; }
        public TimeSpan BusScheduleTime { get; set; }
        public DateTime BusScheduleDate { get; set; }
        public int BusId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }

        public Bus Bus { get; set; }
        public ICollection<StudentBusSchedule> StudentBusSchedule { get; set; }
    }
}
