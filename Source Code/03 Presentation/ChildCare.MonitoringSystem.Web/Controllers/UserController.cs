﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildCare.MonitoringSystem.Business;
using ChildCare.MonitoringSystem.Core.Models;
using ChildCare.MonitoringSystem.Entity;
using ChildCare.MonitoringSystem.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChildCare.MonitoringSystem.Web.Controllers
{
	[Authorize()]
    public class UserController : Controller
    {
		
		private readonly UserBusiness userBusiness;

        private readonly ApplicationContext applicationContext;


        public UserController(UserBusiness userBusiness, ApplicationContext applicationContext)
		{
			this.userBusiness = userBusiness;
            this.applicationContext = applicationContext;
            
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
        public ActionResult<List<UserModel>> GetTeacherDetail()
        {
            var user = this.userBusiness.GetTeacherDetail();
            return user;
        }
        public ActionResult<UserModel> GetUsersInfo()
        {
            var user = this.userBusiness.GetUsersInfo(applicationContext.UserId);
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
        public ActionResult<Int32> UserLogin(UserModel userModel)
        {
            var us= this.userBusiness.UserLogin(userModel);

            return us;

        }
       


    }
}