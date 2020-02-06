using ChildCare.MonitoringSystem.Business;
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
	public class StudentController
	{
		private readonly StudentBusiness studentBusiness;

		public StudentController(StudentBusiness studentBusiness)
		{
			this.studentBusiness = studentBusiness;
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
			var students = this.studentBusiness.StudentGetById(id);
			return students;
		}



		public ActionResult<StudentModel> StudentUpdate(StudentModel studentModel)
		{
			var students = this.studentBusiness.StudentUpdate(studentModel);
			return students;
		}

		public ActionResult<Int32> StudentDeleteId(int id)
		{
			var students = this.studentBusiness.DeleteId(id);
			return students;
		}
	}
}




















































