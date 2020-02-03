using System;
using System.Collections.Generic;
using System.Text;

namespace ChildCare.MonitoringSystem.Model
{
  public  class UserRoleModel
    {
        public int UserRoleId { get; set; } // UserRoleId (Primary key)
        public int UserId { get; set; } // UserId
        public int RoleId { get; set; } // RoleId
      

    }
}
