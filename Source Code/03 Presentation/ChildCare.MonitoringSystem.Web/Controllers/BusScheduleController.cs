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
            var busid = busScheduleModel.BusScheduleId;
			var busSchedule = this.busScheduleBusiness.AddBusSchedule(busScheduleModel);
			if(busSchedule.BusScheduleId>0)
            {
                var busScheduleid = this.busScheduleBusiness.DeleteBusSchedule(busid);
                return busScheduleid;
            }
			return 0;
		}

        //public ActionResult<Int32> DeleteBusSchedule(int id)
        //{
        //    var busSchedule = this.busScheduleBusiness.DeleteBusSchedule(id);
        //    return busSchedule;
        //}
        

        public IActionResult Index()
        {
            return View();
        }

		public ActionResult<List<BusScheduleModel>> GetBusScheduleDetail()
		{
			var busSchedule = this.busScheduleBusiness.GetbusSchedule();
			return busSchedule;
		}

		public ActionResult<List<BusModel>> GetBusDetail()
		{
			var bus = this.busScheduleBusiness.Getbus();
			return bus;
		}


		public ActionResult<BusScheduleModel> BusGetById(int id)
		{
			var bus = this.busScheduleBusiness.BusGetById(id);
			return bus;
		}

		public ActionResult<BusScheduleModel> BusScheduleUpdate(BusScheduleModel busScheduleModel)
		{
			var busSchedule = this.busScheduleBusiness.BusScheduleUpdate(busScheduleModel);
			return busSchedule;
		}

        public ActionResult<BusScheduleModel> GetBusDetailsById(int id)
        {
            var busSchedule = this.busScheduleBusiness.GetBusDetailsById(id);
            return busSchedule;
        }

    }
}