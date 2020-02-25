using ChildCare.MonitoringSystem.Business;
using ChildCare.MonitoringSystem.Model;
using ChildCare.MonitoringSystem.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChildCare.MonitoringSystem.Web.Controllers
{
	[Authorize()]
	public class StudentController :Controller
	{
        private readonly StudentBusiness studentBusiness;
        private readonly string profilePicPath = "profilepics";
        private static List<string> uploadedImages = new List<string>();
        private readonly IHostingEnvironment environment;

        public StudentController(StudentBusiness studentBusiness, IHostingEnvironment environment)
		{
             
			this.studentBusiness = studentBusiness;
            this.environment = environment;
        }


		public ActionResult<StudentModel> AddStudent(StudentModel studentmodel, DemoViewModel demoViewModel)
		{
            string imageName = Guid.NewGuid().ToString() + Path.GetExtension(demoViewModel.ProfilePic.FileName);

            string savePath = Path.Combine(environment.WebRootPath, this.profilePicPath, imageName);

            using (var stream = new FileStream(savePath, FileMode.Create))
            {
                demoViewModel.ProfilePic.CopyTo(stream);
            }
           

            var student = this.studentBusiness.AddStudent(studentmodel);
			return student;
		}
        public ActionResult<StudentModel> StudentRegister(StudentDetail studentDetail)
        {
            
            return null;
        }
        
        public ActionResult<List<StudentModel>> GetStudentDetail()
		{
			var students = this.studentBusiness.GetStudents();
			return students;
		}


		public ActionResult<StudentModel> StudentGetById(int id)
		{
			var students = this.studentBusiness.StudentGetById(id);
			return students;
		}

       


        public ActionResult<StudentModel> StudentUpdate(StudentModel studentModel)
		{
			var students = this.studentBusiness.StudentUpdate(studentModel);
			return students;
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




















































