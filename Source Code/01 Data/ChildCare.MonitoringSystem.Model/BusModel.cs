using System;
using System.Collections.Generic;
using System.Text;

namespace ChildCare.MonitoringSystem.Model
{
	public class BusModel
	{
		public int BusId { get; set; } // BusId (Primary key)
		public string BusName { get; set; } // BusName (length: 100)
        public string BusDriverName { get; set; } // BusDriverName (length: 100)
    }
}
