using System;
using System.Collections.Generic;
using System.Text;

namespace ChildCare.MonitoringSystem.Model
{
    public class RoomVideoModel
    {

        public int RoomVideoId { get; set; } // RoomVideoId (Primary key)
        public string RoomVideoUrlId { get; set; } // RoomVideoUrlId (length: 300)
        public string Path { get; set; } // Path (length: 50)
        public int RoomId { get; set; } // RoomId
        public int CreatedBy { get; set; } // CreatedBy
        public System.DateTime CreatedOn { get; set; } // CreatedOn
        public int UpdatedBy { get; set; } // UpdatedBy
        public System.DateTime UpdatedOn { get; set; } // UpdatedOn
        public bool IsDeleted { get; set; } // IsDeleted
    }
}
