using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildCare.MonitoringSystem.Business;
using ChildCare.MonitoringSystem.Entity;
using ChildCare.MonitoringSystem.Model;
using ChildCare.MonitoringSystem.Web.Models;
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
		public ActionResult<UserModel> AddParent([FromBody]UserModel studentmodel)
		{
			var user = this.userBusiness.AddParent(studentmodel);
			return user;
		}

		public ActionResult<UserModel> AddTeacher([FromBody] UserModel studentmodel)
		{
			var user = this.userBusiness.AddTeacher(studentmodel);
			return user;
		}

        public IActionResult StudentLogin(User teacher)
        {
            return View("HomePage");
        }

        public IActionResult TeacherEditProfile(User teachereditprofile)
        {
            return View("HomePage");
        }

    }
}