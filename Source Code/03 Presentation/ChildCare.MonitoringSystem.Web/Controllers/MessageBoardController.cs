using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildCare.MonitoringSystem.Business;
using ChildCare.MonitoringSystem.Core.Models;
using ChildCare.MonitoringSystem.Entity;
using ChildCare.MonitoringSystem.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChildCare.MonitoringSystem.Web.Controllers
{
	//[Authorize()]
	public class MessageBoardController : Controller
	{
		private readonly MsgBusiness msgBusiness;

        private readonly ApplicationContext applicationContext;

        public MessageBoardController(MsgBusiness msgBusiness, ApplicationContext applicationContext)
        {
            this.msgBusiness = msgBusiness;
            this.applicationContext = applicationContext;
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


        public ActionResult<ArrayList> ViewedMsgDetail()
        {
            var msg = this.msgBusiness.ViewedMsgDetail(applicationContext.UserId);
            //var msgId = msg.MessageBoardId;
            return msg;
        }

        public ActionResult<ArrayList> NewMsgDetail()
        {
            var msg = this.msgBusiness.NewMsgDetail(applicationContext.UserId);

            return msg;
        }

        public ActionResult<int> GetMsgCount()
        {
            var msg = this.msgBusiness.GetMsgCount(applicationContext.UserId);
            //var msgId = msg.MessageBoardId;
            return msg;
        }


        public ActionResult<List<UserModel>> GetMsgUser()
        {
            var msg = this.msgBusiness.GetMsgUser(applicationContext.UserId);
            //var msgId = msg.MessageBoardId;
            return msg;
        }

        //public ActionResult<MessageBoard> GetMsgById(int id)
        //{
        //    var msg = this.msgBusiness.GetMsgById(id);
        //    //var msgId = msg.MessageBoardId;
        //    return msg;
        //}

        public ActionResult<ArrayList> GetMsgById(int id)
        {
            var msg = this.msgBusiness.GetMsgById(id);
            //var msgId = msg.MessageBoardId;
            return msg;
        }
    }
}