using System;
using System.Collections.Generic;

namespace ChildCare.MonitoringSystem.Web.Models
{
    public partial class StudentBusSchedule
    {
        public int StudentBusScheduleId { get; set; }
        public int BusScheduleId { get; set; }
        public int StudentId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }

        public BusSchedule BusSchedule { get; set; }
        public Student Student { get; set; }
    }
}
