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
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChildCare.MonitoringSystem.Web.Controllers
{
    public class ContactController : Controller
    {
		private readonly ContactBusiness contactBusiness;

		private readonly ApplicationContext applicationContext;


		public ContactController(ContactBusiness contactBusiness, ApplicationContext applicationContext)
		{
			this.contactBusiness = contactBusiness;
			this.applicationContext = applicationContext;

		}
		public IActionResult Index()
        {
            return View();
        }

		public ActionResult<ContactModel> AddContact(ContactModel contactmodel)
		{
			var contactinfo = this.contactBusiness.AddContact(contactmodel);
			return contactinfo;
		}

		public ActionResult<ArrayList> ViewContactUsDetail()
		{
			var contact = this.contactBusiness.ViewContactUsDetail();
			//var msgId = msg.MessageBoardId;
			return contact;
		}

		public ActionResult<ArrayList> GetMsgById(int Contactid)
		{
			var msg = this.contactBusiness.GetMsgById(Contactid, applicationContext.UserId);
			//var msgId = msg.MessageBoardId;
			return msg;
		}

		public ActionResult<ContactModel> SendMessage(ContactModel contactmodel)
		{
			var msg = this.contactBusiness.SendMail(contactmodel);
			//var msgId = msg.MessageBoardId;
			return msg;
		}
	}
}