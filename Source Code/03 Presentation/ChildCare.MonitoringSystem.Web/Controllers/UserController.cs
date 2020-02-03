using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildCare.MonitoringSystem.Business;
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
		public ActionResult<Int32> AddParent(UserModel usermodel)
		{
			var user = this.userBusiness.AddParent(usermodel);
            var us = user.UserId;
			return user.UserId;
		}
        [HttpPost]
        public ActionResult<UserModel> AddTeacher(UserModel usermodel)
		{
			var user = this.userBusiness.AddTeacher(usermodel);
			return user;
		}
        public ActionResult<Int32> StudentLogin(StudentModel studentModel)
        {
            var student = this.userBusiness.AddStudent(studentModel);
            return student.StudentId;
        }

        public IActionResult TeacherLogin(UserModel teachermodel)
        {
            return View("HomePage");
        }

    }
}