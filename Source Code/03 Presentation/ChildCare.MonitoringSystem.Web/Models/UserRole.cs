using System;
using System.Collections.Generic;

namespace ChildCare.MonitoringSystem.Web.Models
{
    public partial class UserRole
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }

        public Role Role { get; set; }
        public User User { get; set; }
    }
}
