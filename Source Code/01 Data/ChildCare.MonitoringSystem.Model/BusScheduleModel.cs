using System;
using System.Collections.Generic;
using System.Text;

namespace ChildCare.MonitoringSystem.Model
{
	public class BusScheduleModel
	{
		public int BusScheduleId { get; set; } // BusScheduleId (Primary key)
		public string BusScheduleDriverName { get; set; } // BusScheduleDriverName (length: 100)
		public string ToBusSchedule { get; set; } // ToBusSchedule (length: 100)
		public string FromBusSchedule { get; set; } // FromBusSchedule (length: 100)
		public System.TimeSpan BusScheduleTime { get; set; } // BusScheduleTime
		public System.DateTime BusScheduleDate { get; set; } // BusScheduleDate
		public int BusId { get; set; } // BusId
		public string BusName { get; set; } // BusName (length: 100)
		public BusModel Bus { get; set; }
	}
}
