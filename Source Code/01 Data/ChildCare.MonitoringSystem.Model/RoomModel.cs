using System;
using System.Collections.Generic;
using System.Text;

namespace ChildCare.MonitoringSystem.Model
{
    public class RoomModel
    {
        public int RoomId { get; set; } // RoomId (Primary key)
        public string RoomName { get; set; } // RoomName (length: 100)
    }
}
