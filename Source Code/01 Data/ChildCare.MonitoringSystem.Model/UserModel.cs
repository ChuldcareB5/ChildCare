using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChildCare.MonitoringSystem.Model
{
	public class UserModel
	{
        public int UserId { get; set; } // UserId (Primary key)
        public string UserName { get; set; } // UserName (length: 100)
        public string UserEmail { get; set; } // UserEmail (length: 100)
        public string UserPassword { get; set; } // UserPassword (length: 100)
        public string UserMobileNo { get; set; } // UserMobileNo (length: 12)

        [NotMapped ]
		public RoleModel Role { get; set; }
	}
}
