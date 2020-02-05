using AutoMapper;
using ChildCare.MonitoringSystem.Core.Constraints;
using ChildCare.MonitoringSystem.Entity;
using ChildCare.MonitoringSystem.Model;
using ChildCare.MonitoringSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChildCare.MonitoringSystem.Business
{
	public class StudentBusiness
	{
		private readonly IRepository<User> userRepository;//Connect user Repository
		private readonly IUnitOfWork unitOfWork;

		private readonly IRepository<Student> studentRepository;//Connect student Repository

		public StudentBusiness(IUnitOfWork unitOfWork)
		{
			this.userRepository = unitOfWork.GetRepository<IRepository<User>>();//Get User From Repository
			this.studentRepository = unitOfWork.GetRepository<IRepository<Student>>();//Get User From Repository
			this.unitOfWork = unitOfWork;//Instantiate unitOfWork Variable
		}

		public StudentModel AddStudent(StudentModel studentModel)
		{
			/* this.AddStudent(studentModel, 2);*///Return from method named AddUser where parent id is 2(function call)


			var studentEntity = new Student()
			{
				StudentName = studentModel.StudentName,
				StudentImg = studentModel.StudentImg,
				StudentAddress = studentModel.StudentAddress,
				StudentGender = studentModel.StudentGender,
				StudentDob = studentModel.StudentDob,
				FatherName = studentModel.FatherName,
				MotherName = studentModel.MotherName,
				ParentId = studentModel.ParentId,
				Batch = studentModel.Batch,
				CreatedBy = -1,
				CreatedOn = DateTime.UtcNow,
				UpdatedBy = -1,
				UpdatedOn = DateTime.UtcNow
			};

			this.studentRepository.Add(studentEntity);
			this.unitOfWork.Save();
			studentModel.StudentId = studentEntity.StudentId;

			return studentModel;
		}

        public List<StudentModel> GetStudents()
        {
            var studentsEntity = this.studentRepository.GetAll();

            var students = new List<StudentModel>();

			foreach (var student in studentsEntity)
			{
				students.Add(new StudentModel()
				{
					StudentId = student.StudentId,
					StudentName = student.StudentName,
					StudentImg = student.StudentImg,
					StudentAddress = student.StudentAddress,
					StudentGender = student.StudentGender,
					StudentDob = student.StudentDob,
					FatherName = student.FatherName,
					MotherName = student.MotherName,
					ParentId = student.ParentId
				});
			}

			return students;
		}



		public StudentModel StudentGetById(int id)
		{

			var student = this.studentRepository.GetBy(x => x.StudentId == id, x => x.User).SingleOrDefault();
			return Mapper.Map<StudentModel>(student);
		}


		public StudentModel StudentUpdate(StudentModel studentModel)
		{
			var studentupdate = this.studentRepository.GetBy(x => x.StudentId == studentModel.StudentId, x=> x.User).SingleOrDefault();

			studentupdate.StudentName = studentModel.StudentName;
			studentupdate.StudentImg = studentModel.StudentImg;
			studentupdate.StudentAddress = studentModel.StudentAddress;
			studentupdate.StudentGender = studentModel.StudentGender;
			studentupdate.StudentDob = studentModel.StudentDob;
			studentupdate.FatherName = studentModel.FatherName;
			studentupdate.MotherName = studentModel.MotherName;
			studentupdate.User.UserName = studentModel.User.UserName;
			studentupdate.User.UserEmail = studentModel.User.UserEmail;
			studentupdate.User.UserMobileNo = studentModel.User.UserMobileNo;
	

			this.unitOfWork.Save();

			return studentModel;



			
		}



		public Int32 DeleteId(int id)
		{

			var studentid = this.studentRepository.GetBy(x => x.StudentId == id).SingleOrDefault();
			studentid.IsDeleted = true;
			this.unitOfWork.Save();
			return studentid != null ? 0 : 1;

		}
	}
}
