using System;
using System.Collections.Generic;

namespace ChildCare.MonitoringSystem.Web.Models
{
    public partial class User
    {
        public User()
        {
            MessageBoardFromMsgNavigation = new HashSet<MessageBoard>();
            MessageBoardToMsgNavigation = new HashSet<MessageBoard>();
            RoomSchedule = new HashSet<RoomSchedule>();
            Student = new HashSet<Student>();
            UserRole = new HashSet<UserRole>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserMobileNo { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<MessageBoard> MessageBoardFromMsgNavigation { get; set; }
        public ICollection<MessageBoard> MessageBoardToMsgNavigation { get; set; }
        public ICollection<RoomSchedule> RoomSchedule { get; set; }
        public ICollection<Student> Student { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
    }
}
