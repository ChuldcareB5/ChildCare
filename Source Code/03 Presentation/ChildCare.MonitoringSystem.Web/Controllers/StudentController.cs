using ChildCare.MonitoringSystem.Business;
using ChildCare.MonitoringSystem.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
using ChildCare.MonitoringSystem.Entity;

namespace ChildCare.MonitoringSystem.Web.Controllers
{
	//[Authorize(Roles ="1")]
	//[Authorize]
	public class StudentController :Controller
	{
        private readonly ApplicationContext applicationContext; 
		private readonly StudentBusiness studentBusiness;
		private readonly string profilePicPath = "profilepics";
		private static List<string> uploadedImages = new List<string>();
		private readonly IHostingEnvironment environment;

		public StudentController(StudentBusiness studentBusiness,ApplicationContext applicationContext, IHostingEnvironment environment)
		{
			this.studentBusiness = studentBusiness;
            this.applicationContext = applicationContext;
			this.environment = environment;
		}



		public ActionResult<StudentModel> AddStudent(StudentModel studentmodel)
		{
			var student = this.studentBusiness.AddStudent(studentmodel);
			return student;
		}


		public ActionResult<List<StudentModel>> GetStudentDetail(String batch)
		{
			var students = this.studentBusiness.GetStudents(batch);
			return students;
		}


		public ActionResult<StudentModel> StudentGetById(int id)
		{
			var students = this.studentBusiness.StudentGetById(id);
			return students;
		}
        public ActionResult<StudentModel> GetUsersStudentInfo()
        {
            var students = this.studentBusiness.GetUsersStudentInfo(applicationContext.UserId);
            return students;
        }

		[HttpPost]
        public ActionResult<StudentDetail> StudentUpdate(StudentDetail studentModel,String oldimage)
		{
		
			string imageName = Guid.NewGuid().ToString() + Path.GetExtension(studentModel.StudentImg.FileName);	
			string savePath = Path.Combine(environment.WebRootPath, this.profilePicPath, imageName);
			
			oldimage = Path.GetFileName(oldimage);
			using (var stream = new FileStream(savePath, FileMode.OpenOrCreate))
			{
				studentModel.StudentImg.CopyTo(stream);
			}
			uploadedImages.Add(imageName);
			imageName = "/profilepics/" + imageName;

			StudentModel studentModel1 = new StudentModel();
			UserModel userModel = new UserModel();

			studentModel1.StudentId = studentModel.StudentId;
			studentModel1.StudentName = studentModel.StudentName;
			studentModel1.StudentImg = imageName;
			studentModel1.StudentAddress = studentModel.StudentAddress;
			studentModel1.StudentGender = studentModel.StudentGender;
			studentModel1.StudentDob = studentModel.StudentDob;
			studentModel1.FatherName = studentModel.FatherName;
			studentModel1.MotherName = studentModel.MotherName;
			userModel.UserName = studentModel.UserName;
			userModel.UserName = studentModel.UserName;
			userModel.UserEmail = studentModel.UserEmail;
			userModel.UserMobileNo = studentModel.UserMobileNo;

			var student = this.studentBusiness.StudentUpdate(studentModel1, userModel);
			return RedirectToAction("StudentView", "Dashboard");
			//return null;
		}


        public ActionResult<StudentLocationModel> GetStudentLocation()
        {
            var studentlocation = this.studentBusiness.GetStudentLocation(applicationContext.UserId);
            return studentlocation;
        }
        public ActionResult<List<StudentLocationModel>> GetAllStudentLocation()
        {
            var studentlocation = this.studentBusiness.GetAllStudentLocation(applicationContext.UserId);
            return studentlocation;
        }
        public ActionResult<BusLocationModel> GetBusLocation()
        {
            var studentlocation = this.studentBusiness.GetBusLocation(applicationContext.UserId);
            return studentlocation;
        }public ActionResult<List<BusLocationModel>> GetAllBusLocation()
        {
            var studentlocation = this.studentBusiness.GetAllBusLocation(applicationContext.UserId);
            return studentlocation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult<Int32> StudentDeleteId(int id)
		{
			var students = this.studentBusiness.DeleteId(id);
			return students;
		}
	}
}




















































