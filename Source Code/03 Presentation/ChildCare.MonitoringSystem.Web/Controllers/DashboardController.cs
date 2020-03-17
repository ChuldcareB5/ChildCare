
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

namespace ChildCare.MonitoringSystem.Web.Controllers
{
	
    public class DashboardController : Controller
    {
        private readonly StudentBusiness studentBusiness;
        private readonly UserBusiness userBusiness;
        private readonly string profilePicPath = "profilepics";
        private static List<string> uploadedImages = new List<string>();
        private readonly IHostingEnvironment environment;

        public DashboardController(StudentBusiness studentBusiness,UserBusiness userBusiness, IHostingEnvironment environment)
		{
            this.studentBusiness = studentBusiness;
            this.userBusiness = userBusiness;
            this.environment = environment;
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
                userModel.UserEmail = studentDetail.UserName;
                userModel.UserPassword = studentDetail.UserName;
                userModel.UserMobileNo = studentDetail.UserName;
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
                var student = this.studentBusiness.AddStudent(studentModel);
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

