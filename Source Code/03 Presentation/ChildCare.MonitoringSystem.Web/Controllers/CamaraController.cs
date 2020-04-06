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

		public IActionResult Cam1()
		{
			return View();
		}

	}
}
