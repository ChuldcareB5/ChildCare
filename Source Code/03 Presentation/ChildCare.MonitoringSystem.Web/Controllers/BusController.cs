﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildCare.MonitoringSystem.Business;
using ChildCare.MonitoringSystem.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChildCare.MonitoringSystem.Web.Controllers
{
	//[Authorize()]
    public class BusController : Controller
    {

		private readonly BusBusiness busBusiness;
        private readonly BusScheduleBusiness busScheduleBusiness;
		public BusController(BusBusiness busBusiness,BusScheduleBusiness busScheduleBusiness)
		{
			this.busBusiness = busBusiness;
            this.busScheduleBusiness = busScheduleBusiness;
		}


		[HttpPost]
		public ActionResult<Int32> AddBus(BusModel busmodel,BusScheduleModel busScheduleModel)
		{
			var bus = this.busBusiness.AddBus(busmodel);
            busScheduleModel.BusId = bus.BusId;
            var busSchedule = this.busScheduleBusiness.AddBusSchedule(busScheduleModel);
            return bus.BusId;

          
		}

		public IActionResult Index()
        {
            return View();
        }
		public ActionResult<List<BusScheduleModel>> getbusshedule(String To)
		{
			var buses = this.busBusiness.getbusshedule(To);
			return buses;
		}

        public ActionResult<ArrayList> getBusDestination()
        {
            var buses = this.busBusiness.getBusDestination();
            return buses;
        }

        public ActionResult<Int32> BusDeleteId(int id)
		{
			var bus = this.busBusiness.DeleteId(id);
			return bus;
		}public ActionResult<BusModel> BusGetById(int id)
		{
			var bus = this.busBusiness.BusGetById(id);
			return bus;
		}
        public ActionResult<BusModel> UpdateBusSchedule(BusModel busModel)
        {
            var bus = this.busBusiness.UpdateBusSchedule(busModel);
            return bus;
        }

    }
}