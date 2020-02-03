using System;
using System.Collections.Generic;
using System.Text;

namespace ChildCare.MonitoringSystem.Model
{
	public class MessageBoardModel
	{
		public int MessageBoardId { get; set; } // MessageBoardId (Primary key)
		public int ToMsg { get; set; } // ToMsg
		public int FromMsg { get; set; } // FromMsg
		public int MsgStatus { get; set; } // MsgStatus
		public System.DateTime MsgDateTime { get; set; } // MsgDateTime
		public string Msg { get; set; } // Msg (length: 500)
	}
}
