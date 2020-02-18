using ChildCare.MonitoringSystem.Business;
using ChildCare.MonitoringSystem.Core.Models;
using ChildCare.MonitoringSystem.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildCare.MonitoringSystem.Web.Controllers
{
	[Authorize()]
	public class StudentController :Controller
	{
        private readonly ApplicationContext applicationContext; 
		private readonly StudentBusiness studentBusiness;

		public StudentController(StudentBusiness studentBusiness,ApplicationContext applicationContext)
		{
			this.studentBusiness = studentBusiness;
            this.applicationContext = applicationContext;
		}



		public ActionResult<StudentModel> AddStudent(StudentModel studentmodel)
		{
			var student = this.studentBusiness.AddStudent(studentmodel);
			return student;
		}


		public ActionResult<List<StudentModel>> GetStudentDetail()
		{
			var students = this.studentBusiness.GetStudents();
			return students;
		}


		public ActionResult<StudentModel> StudentGetById(int id)
		{
			var students = this.studentBusiness.StudentGetById(applicationContext.UserId);
			return students;
		}
        public ActionResult<StudentModel> CookieId()
        {
            var students = this.studentBusiness.CookieId(applicationContext.UserId);
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




















































