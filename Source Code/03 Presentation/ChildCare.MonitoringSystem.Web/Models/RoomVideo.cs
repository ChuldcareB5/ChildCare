using System;
using System.Collections.Generic;

namespace ChildCare.MonitoringSystem.Web.Models
{
    public partial class RoomVideo
    {
        public int RoomVideoId { get; set; }
        public string RoomVideo1 { get; set; }
        public int RoomId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }

        public Room Room { get; set; }
    }
}
