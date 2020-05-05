
﻿using System;
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
using Microsoft.AspNetCore.Hosting;
using System.IO;
using ChildCare.MonitoringSystem.Core.Models;

namespace ChildCare.MonitoringSystem.Web.Controllers
{
    [Authorize(Roles = "1")]
    public class DashboardController : Controller
	{
		private readonly ApplicationContext applicationContext;
		private readonly StudentBusiness studentBusiness;
		private readonly UserBusiness userBusiness;
		private readonly string profilePicPath = "profilepics";
		private static List<string> uploadedImages = new List<string>();
		private readonly IHostingEnvironment environment;
        private readonly MsgBusiness msgBusiness;

        public DashboardController(StudentBusiness studentBusiness, ApplicationContext applicationContext, UserBusiness userBusiness, IHostingEnvironment environment, MsgBusiness msgBusiness)
		{
			this.studentBusiness = studentBusiness;
			this.userBusiness = userBusiness;
			this.applicationContext = applicationContext;
			this.environment = environment;
            this.msgBusiness = msgBusiness;

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

        public IActionResult ParentCamaraView()
        {
            return View();
        }

        public IActionResult BusTracking()
        {
            return View();
        }
        public IActionResult StudentTracking()
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

	

		public ActionResult<Int32> GetUserId()
		{
			var userid = this.userBusiness.GetUserId(applicationContext.UserId);
			return userid;
		}


       
        [HttpPost]
        public IActionResult StudentRegistration(StudentDetail studentDetail)
        {
            try
            {
                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(studentDetail.StudentImg.FileName);

                string savePath = Path.Combine(environment.WebRootPath, this.profilePicPath, imageName);
                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    studentDetail.StudentImg.CopyTo(stream);
                }
                uploadedImages.Add(imageName);
                imageName = "/profilepics/" + imageName;
                StudentModel studentModel = new StudentModel();
                UserModel userModel = new UserModel();
                userModel.UserName = studentDetail.UserName;
                userModel.UserEmail = studentDetail.UserEmail;
                userModel.UserPassword = studentDetail.UserPassword;
                userModel.UserMobileNo = studentDetail.UserMobileNo;
                var user = this.userBusiness.AddParent(userModel);
                studentModel.StudentName = studentDetail.StudentName;
                studentModel.StudentImg = imageName;
                studentModel.StudentAddress = studentDetail.StudentAddress;
                studentModel.StudentGender = studentDetail.StudentGender;
                studentModel.StudentDob = studentDetail.StudentDob;
                studentModel.FatherName = studentDetail.FatherName;
                studentModel.MotherName = studentDetail.MotherName;
                studentModel.ParentId = user.UserId;
                studentModel.Batch = studentDetail.Batch;
             var student = this.studentBusiness.AddStudent(studentModel, studentDetail.Sheduleid);
				ModelState.AddModelError(nameof(StudentDetail.ErrorMessage), "Registered Successfully");
				

			}
            catch (Exception e)
            {
                ModelState.AddModelError(nameof(StudentDetail.ErrorMessage), "Failed to register due to "+e);
            }



            return View(studentDetail);
        }
        }
}

