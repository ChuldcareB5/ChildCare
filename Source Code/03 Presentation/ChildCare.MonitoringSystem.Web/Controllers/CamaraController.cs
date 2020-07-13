using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ChildCare.MonitoringSystem.Web.Controllers
{
	[Authorize]
	public class CamaraController : Controller
	{
		public CamaraController()
		{
				
		}

		public IActionResult ClassA()
		{
			return View();
		}

		public IActionResult ClassB()
		{
			return View();
		}

		public IActionResult ClassC()
		{
			return View();
		}

		public IActionResult StudentCamera()
		{
			return View();
		}

		public IActionResult PlayGround()
		{
			return View();
		}

	}
}
