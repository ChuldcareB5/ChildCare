using System;
using System.Collections.Generic;

namespace ChildCare.MonitoringSystem.Web.Models
{
    public partial class RoomSchedule
    {
        public int RoomScheduleId { get; set; }
        public int TeacherId { get; set; }
        public DateTime RoomScheduleDate { get; set; }
        public TimeSpan RoomScheduleTime { get; set; }
        public string RoomScheduleSubject { get; set; }
        public int StudentId { get; set; }
        public int RoomId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }

        public Room Room { get; set; }
        public Student Student { get; set; }
        public User Teacher { get; set; }
    }
}
