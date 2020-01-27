using System;
using System.Collections.Generic;

namespace ChildCare.MonitoringSystem.Web.Models
{
    public partial class MessageBoard
    {
        public int MsgId { get; set; }
        public int ToMsg { get; set; }
        public int FromMsg { get; set; }
        public int MsgStatus { get; set; }
        public DateTime MsgDateTime { get; set; }
        public string Msg { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }

        public User FromMsgNavigation { get; set; }
        public User ToMsgNavigation { get; set; }
    }
}
