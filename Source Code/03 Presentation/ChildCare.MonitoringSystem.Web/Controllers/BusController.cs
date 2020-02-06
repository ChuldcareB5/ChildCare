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
    public class BusController : Controller
    {

		private readonly BusBusiness busBusiness;
		public BusController(BusBusiness busBusiness)
		{
			this.busBusiness = busBusiness;
		}

		[HttpPost]
		public ActionResult<Int32> AddBus(BusModel busmodel)
		{
			var bus = this.busBusiness.AddBus(busmodel);
			var BusId = bus.BusId;
			return BusId; 
		}
		public IActionResult Index()
        {
            return View();
        }
		public ActionResult<List<BusModel>> GetBusDetail()
		{
			var bus = this.busBusiness.Getbus();
			return bus;
		}

		public ActionResult<Int32> BusDeleteId(int id)
		{
			var bus = this.busBusiness.DeleteId(id);
			return bus;
		}


		public ActionResult<BusModel> BusGetById(int id)
		{
			var bus = this.busBusiness.BusGetById(id);
			return bus;
		}


		//public ActionResult<List<BusModel>> BusScheduleUpdate(BusModel busModel)
		//{
		//	var bus = this.busBusiness.BusScheduleUpdate(busModel);
		//	return bus;
		//}
	}
}