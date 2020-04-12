using System;
using System.Collections.Generic;
using System.Text;

namespace ChildCare.MonitoringSystem.Model
{
    public class RoomScheduleModel
    {
        public int RoomScheduleId { get; set; } // RoomScheduleId (Primary key)
        public int TeacherId { get; set; } // TeacherId
        public System.DateTime RoomScheduleDate { get; set; } // RoomScheduleDate
        public System.TimeSpan RoomScheduleTime { get; set; } // RoomScheduleTime
        public string RoomScheduleSubject { get; set; } // RoomScheduleSubject (length: 100)
        public int StudentId { get; set; } // StudentId
        public int RoomId { get; set; } // RoomId
        public string RoomName { get; set; } // RoomName
    }
}
    