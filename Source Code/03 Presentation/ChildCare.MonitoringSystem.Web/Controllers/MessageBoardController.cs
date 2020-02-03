using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildCare.MonitoringSystem.Business;
using ChildCare.MonitoringSystem.Model;
using Microsoft.AspNetCore.Mvc;

namespace ChildCare.MonitoringSystem.Web.Controllers
{
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

        public ActionResult<Int32> SendMessage(MessageBoardModel msgboardmodel)
        {
            var msg = this.msgBusiness.SendMail(msgboardmodel);
            return msg;
        }
    }
}