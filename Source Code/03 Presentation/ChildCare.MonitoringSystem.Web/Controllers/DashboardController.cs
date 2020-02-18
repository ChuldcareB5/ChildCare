using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChildCare.MonitoringSystem.Web.Models;
using ChildCare.MonitoringSystem.Model;
using ChildCare.MonitoringSystem.Business;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace ChildCare.MonitoringSystem.Web.Controllers
{
	[Authorize]
    public class DashboardController : Controller
    {
		public DashboardController()
		{
			
		}
		public IActionResult StudentRegistration()
		{
			return View("StudentRegistration");
		}

		public IActionResult TeacherRegistration()
		{
			return View();
		}


		public IActionResult StudentView()
		{
			return View();
		}

		public IActionResult CamaraView()
		{
			return View();
		}

		public IActionResult RoomSchedule()
		{
			return View();
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult BusSchedule()
		{
			return View();
		}

	}
}
