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

namespace ChildCare.MonitoringSystem.Web.Controllers
{
    public class HomeController : Controller
    {
		private readonly UserBusiness userBusiness;

		public HomeController(UserBusiness userBusiness)
		{
			this.userBusiness = userBusiness;
		}

		public IActionResult Contact()
		{
			//ViewData["Message"] = "Your contact page.";

			return View("Contact");
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
		//public IActionResult Form()
		//{
		//	var model = new UserModel();
		//	model.UserName = "test";
		//	return View("StudentRegistration", model);
		//}
		//public IActionResult Form1()
		//{
		//	return View("TeacherRegistration");
		//}
		public IActionResult Calender()
		{
			return View("Calender");
		}
		public IActionResult Calender1()
		{
			return View("Calender1");
		}
		//public IActionResult CamaraView()
		//{
		//	return View("CamaraView");
		//}
		public IActionResult BusTracking()
		{
			return View("BusTracking");
		}
		//public IActionResult BusSchedule()
		//{
		//	return View("BusSchedule");
		//}
		public IActionResult StudentLocation()
		{
			return View("StudentLocation");
		}
		//public IActionResult StudentDetails()
		//{
		//	return View("StudentView");
		//}
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

        //public IActionResult RoomSchedule()
        //{
        //    return View("RoomSchedule");
        //}

		public IActionResult ParentStudentLocation()
		{
			return View("ParentStudentLocation");
		}

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> LogIn(LoginViewModel loginViewModel)
		{
			if (ModelState.IsValid)
			{
				if (HttpContext.User.Identity.IsAuthenticated)//check authentication of user
				{
					var user = this.userBusiness.GetUser(loginViewModel.UserName, loginViewModel.Password);//get user from userbussiness

					if (user != null)
					{
						var claims = new List<Claim>
						{
							new Claim(ClaimTypes.Name, user.UserName),
							new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
							new Claim(ClaimTypes.Role, user.Role.RoleId.ToString())
						};

						var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);//cookie authentication
						var principal = new ClaimsPrincipal(identity);

						await HttpContext.SignInAsync(principal);

						return RedirectToAction("Index", "Home");
					}
					else
					{
						ModelState.AddModelError(nameof(LoginViewModel.ErrorMessage), "Invalid user name or password!");
					}
				}
				else
				{
					return RedirectToAction("Index", "Home");
				}
			}

			return View(loginViewModel);
		}
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
