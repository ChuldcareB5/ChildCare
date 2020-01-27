using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChildCare.MonitoringSystem.Web.Models;

namespace ChildCare.MonitoringSystem.Web.Controllers
{
    public class HomeController : Controller
    {


		public IActionResult Contact()
		{
			//ViewData["Message"] = "Your contact page.";

			return View("Contact");
		}

		public IActionResult Mainpage()
		{
			return View("HomePage");
		}

		public IActionResult Student()
		{
			return View("Student");
		}

		public IActionResult Camera()
		{
			return View("Camera");
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}
		

		public IActionResult submit()
		{
			return View("HomePage");
		}
		public IActionResult Dashboard()
		{
			return View("admin");
		}
		public IActionResult Form()
		{
			return View("StudentRegistration");
		}
		public IActionResult Form1()
		{
			return View("TeacherRegistration");
		}
		public IActionResult Calender()
		{
			return View("Calender");
		}
		public IActionResult Calender1()
		{
			return View("Calender1");
		}
		public IActionResult CamaraView()
		{
			return View("CamaraView");
		}
		public IActionResult BusTracking()
		{
			return View("BusTracking");
		}
		public IActionResult BusSchedule()
		{
			return View("BusSchedule");
		}
		public IActionResult StudentLocation()
		{
			return View("StudentLocation");
		}
		public IActionResult StudentDetails()
		{
			return View("StudentView");
		}
		public IActionResult StudentClassDetails()
		{
			return View("StudentDetails");
		}
		public IActionResult ParentAccount()
		{
			return View("ParentAccount");
		}
		public IActionResult StudentCameraView()
		{
			return View("CameraView");
		}
		public IActionResult Onclicks()
		{
			return View("Onclicks");
		}
		public IActionResult ClassRooms()
		{
			return View("ClassRooms");
		}
		public IActionResult PlayGround()
		{
			return View("PlayGround");
		}
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
