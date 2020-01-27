using System;
using System.Collections.Generic;

namespace ChildCare.MonitoringSystem.Web.Models
{
    public partial class Room
    {
        public Room()
        {
            RoomSchedule = new HashSet<RoomSchedule>();
            RoomVideo = new HashSet<RoomVideo>();
        }

        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<RoomSchedule> RoomSchedule { get; set; }
        public ICollection<RoomVideo> RoomVideo { get; set; }
    }
}
