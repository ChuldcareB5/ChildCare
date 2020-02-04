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
    public class BusScheduleController : Controller
    {
		private readonly BusScheduleBusiness busScheduleBusiness;

		public BusScheduleController(BusScheduleBusiness busScheduleBusiness)
		{
			this.busScheduleBusiness = busScheduleBusiness;
		}

		[HttpPost]
		public ActionResult<Int32> AddBusSchedule(BusScheduleModel busScheduleModel)
		{
			var busSchedule = this.busScheduleBusiness.AddBusSchedule(busScheduleModel);
			var BusScheduleId = busSchedule.BusScheduleId;
			return BusScheduleId;
		}

		public IActionResult Index()
        {
            return View();
        }

		public ActionResult<List<BusScheduleModel>> GetBusScheduleDetail()
		{
			var busSchedule = this.busScheduleBusiness.GetbusSchedule();
			return busSchedule;
		}

	}
}