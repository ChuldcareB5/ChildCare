using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildCare.MonitoringSystem.Business;
using Microsoft.AspNetCore.Mvc;

namespace ChildCare.MonitoringSystem.Web.Controllers
{
    public class RoomScheduleController : Controller
    {
		private readonly RoomScheduleBusiness roomscheduleBusiness;

		//public IActionResult Index()
  //      {
  //          return View();
  //      }
		public RoomScheduleController(RoomScheduleBusiness roomscheduleBusiness)
		{
			this.roomscheduleBusiness = roomscheduleBusiness;
		}


		public ActionResult<Int32> RoomScheduleDeleteId(int id)
		{
			var students = this.roomscheduleBusiness.DeleteId(id);
			return students;
		}
	}
}