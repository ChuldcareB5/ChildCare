using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildCare.MonitoringSystem.Business;
using ChildCare.MonitoringSystem.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChildCare.MonitoringSystem.Web.Controllers
{
	[Authorize()]
	public class MessageBoardController : Controller
	{
		private readonly MsgBusiness msgBusiness;

		public MessageBoardController(MsgBusiness msgBusiness)
		{
			this.msgBusiness = msgBusiness;
		}
		public IActionResult Index()
		{
			return View();
		}

		public ActionResult<MessageBoardModel> SendMessage(MessageBoardModel msgboardmodel)
		{
			var msg = this.msgBusiness.SendMail(msgboardmodel);
			//var msgId = msg.MessageBoardId;
			return msg;
		}

		

		public ActionResult<MessageBoardModel> SendParentMessage(MessageBoardModel msgboardmodel)
		{
			var msg = this.msgBusiness.SendParentMail(msgboardmodel);
			//var msgId = msg.MessageBoardId;
			return msg;
		}
	}
}