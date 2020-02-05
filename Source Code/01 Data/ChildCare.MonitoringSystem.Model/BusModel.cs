using System;
using System.Collections.Generic;
using System.Text;

namespace ChildCare.MonitoringSystem.Model
{
	public class BusModel
	{
		public int BusId { get; set; } // BusId (Primary key)
		public string BusName { get; set; } // BusName (length: 100)
        public List<BusScheduleModel> BusSchedule { get; set; } // BusSchedule.FK_BusSchedule_Bus

    }
}
