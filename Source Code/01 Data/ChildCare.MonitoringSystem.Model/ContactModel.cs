using System;
using System.Collections.Generic;
using System.Text;

namespace ChildCare.MonitoringSystem.Model
{
	public class ContactModel
	{
		public int ContactId { get; set; } // ContactId (Primary key)
		public string ContactName { get; set; } // ContactName (length: 100)
		public string ContactEmail { get; set; } // ContactEmail (length: 100)
		public string ContactMobileNo { get; set; } // ContactMobileNo (length: 12)
		public string ContactMsg { get; set; } // ContactMsg (length: 500)
		public int CreatedBy { get; set; } // CreatedBy
		public System.DateTime CreatedOn { get; set; } // CreatedOn
		public int UpdatedBy { get; set; } // UpdatedBy
		public System.DateTime UpdatedOn { get; set; } // UpdatedOn
		public bool IsDeleted { get; set; } // IsDeleted
	}
}
