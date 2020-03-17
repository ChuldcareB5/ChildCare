using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildCare.MonitoringSystem.Business;
using ChildCare.MonitoringSystem.Entity;
using ChildCare.MonitoringSystem.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ChildCare.MonitoringSystem.Web.Controllers
{
    
    [Authorize()]
    public class UserController : Controller
    {
		
		private readonly UserBusiness userBusiness;
        private readonly StudentBusiness studentBusiness;

		public UserController(UserBusiness userBusiness,StudentBusiness studentBusiness)
		{
			this.userBusiness = userBusiness;
            this.studentBusiness = studentBusiness;
        }

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Student()

        {
			return View();
		}
		public IActionResult Camera()
		{
			return View();
		}
		public IActionResult BusTracking()
		{
			return View();
		}
		public ActionResult<UserModel> Get(int userId)
		{
			return this.userBusiness.GetUserById(userId);
		}

	
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