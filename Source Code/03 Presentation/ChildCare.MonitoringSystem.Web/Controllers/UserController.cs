using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildCare.MonitoringSystem.Business;
using ChildCare.MonitoringSystem.Entity;
using ChildCare.MonitoringSystem.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChildCare.MonitoringSystem.Web.Controllers
{
    public class UserController : Controller
    {
		
		private readonly UserBusiness userBusiness;
		

		public UserController(UserBusiness userBusiness)
		{
			this.userBusiness = userBusiness;
		}

		public ActionResult<UserModel> Get(int userId)
		{
			return this.userBusiness.GetUserById(userId);
		}

		[HttpPost]
		public ActionResult<Int32> AddParent(UserModel usermodel)
		{
			var user = this.userBusiness.AddParent(usermodel);
			var userId = user.UserId;
			return user.UserId; ;
		}

		public ActionResult<UserModel> AddTeacher(UserModel usermodel)
		{
			var user = this.userBusiness.AddTeacher(usermodel);
			return user;
		}

		

		[HttpPost]
		public IActionResult StudentLogin(UserModel userModel)
		{
			return View("HomePage");
		}

		public IActionResult TeacherLogin(User teachereditprofile)
		{
			return View("HomePage");
		}

    }
}