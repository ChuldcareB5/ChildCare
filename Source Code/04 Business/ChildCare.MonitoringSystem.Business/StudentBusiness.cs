using AutoMapper;
using ChildCare.MonitoringSystem.Core.Constraints;
using ChildCare.MonitoringSystem.Entity;
using ChildCare.MonitoringSystem.Model;
using ChildCare.MonitoringSystem.Repository;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ChildCare.MonitoringSystem.Business
{
	public class StudentBusiness
	{
        private static List<string> uploadedImages = new List<string>();

        
        private readonly string profilePicPath = "profilepics";

        private readonly IRepository<User> userRepository;//Connect user Repository
		private readonly IUnitOfWork unitOfWork;
		//private readonly IHostingEnvironment environment;
		private readonly IRepository<Student> studentRepository;//Connect student Repository
        private readonly IRepository<StudentLocation> studentlocationRepository;
        private readonly IRepository<BusLocation> buslocationRepository;
        private readonly IRepository<StudentBusSchedule> studentbusschedulRepository;
        private readonly IRepository<BusSchedule> busscheuleRepository;
        private readonly IRepository<Bus> busRepository;


        public StudentBusiness(IUnitOfWork unitOfWork)
		{
			this.userRepository = unitOfWork.GetRepository<IRepository<User>>();//Get User From Repository
			this.studentRepository = unitOfWork.GetRepository<IRepository<Student>>();//Get User From Repository
            this.studentlocationRepository = unitOfWork.GetRepository<IRepository<StudentLocation>>();
            this.buslocationRepository = unitOfWork.GetRepository<IRepository<BusLocation>>();
            this.studentbusschedulRepository = unitOfWork.GetRepository<IRepository<StudentBusSchedule>>();
            this.busscheuleRepository = unitOfWork.GetRepository<IRepository<BusSchedule>>();
            this.busRepository = unitOfWork.GetRepository<IRepository<Bus>>();
            this.unitOfWork = unitOfWork;//Instantiate unitOfWork Variable
		}

		public StudentModel AddStudent(StudentModel studentModel, int Sheduleid)
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
            if(Sheduleid!=0)
            {
                studentEntity.StudentBusSchedule.Add(new StudentBusSchedule()
                {
                    BusScheduleId = Sheduleid
                });
            }
           

            this.studentRepository.Add(studentEntity);
			this.unitOfWork.Save();
			studentModel.StudentId = studentEntity.StudentId;

			return studentModel;
		}

        public List<StudentModel> GetStudents(String batch)
        {
            var studentsEntity = this.studentRepository.GetBy(x => x.Batch == batch);

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
			var st=Mapper.Map<StudentModel>(student);
			//string imageName = Guid.NewGuid().ToString() + Path.PathSeparator(student.StudentImg);
			//st.StudentImg = Path.GetFileName(st.StudentImg);
			return st;
		}
        public StudentModel CookieId(int id)
		{

			var student = this.studentRepository.GetBy(x => x.ParentId == id, x=>x.User).SingleOrDefault();
			return Mapper.Map<StudentModel>(student);
		}


		public StudentModel StudentUpdate(StudentModel studentModel,UserModel userModel)
		{
			var studentupdate = this.studentRepository.GetBy(x => x.StudentId == studentModel.StudentId, x=> x.User).SingleOrDefault();
			studentupdate.StudentName = studentModel.StudentName;
			studentupdate.StudentImg = studentModel.StudentImg;
			studentupdate.StudentAddress = studentModel.StudentAddress;
			studentupdate.StudentGender = studentModel.StudentGender;
			studentupdate.StudentDob = studentModel.StudentDob;
			studentupdate.FatherName = studentModel.FatherName;
			studentupdate.MotherName = studentModel.MotherName;
			studentupdate.User.UserName = userModel.UserName;
			studentupdate.User.UserEmail = userModel.UserEmail;
			studentupdate.User.UserMobileNo = userModel.UserMobileNo;

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
        public StudentModel GetUsersStudentInfo(int id)
        {

            var student = this.studentRepository.GetBy(x => x.ParentId == id, x => x.User).SingleOrDefault();
            return Mapper.Map<StudentModel>(student);
        }
        public StudentLocationModel GetStudentLocation(int parentid)
        {
            var studentid = this.studentRepository.GetBy(x => x.ParentId == parentid).SingleOrDefault();
            var studentlocation = this.studentlocationRepository.GetBy(x => x.StudentId == studentid.StudentId).Last();
            return Mapper.Map<StudentLocationModel>(studentlocation); ;
        }
        public List<StudentLocationModel> GetAllStudentLocation(int studentid)
        {
            if(studentid==0)
            {
                var studentsEntity = this.studentRepository.GetAll();
                var studentsloclist = new List<StudentLocationModel>();
                foreach (var student in studentsEntity)
                {
                    var studentlocation = this.studentlocationRepository.GetBy(x => x.StudentId == student.StudentId).LastOrDefault();
                    if (studentlocation != null)
                    {
                        var stud = Mapper.Map<StudentLocationModel>(studentlocation);
                        studentsloclist.Add(stud);
                    }
                }
                return studentsloclist;
            }
            else
            {
                var studentsEntit = this.studentRepository.GetBy(x => x.StudentId == studentid);
                var studentsloclist = new List<StudentLocationModel>();
                foreach (var student in studentsEntit)
                {
                    var studentlocation = this.studentlocationRepository.GetBy(x => x.StudentId == student.StudentId).LastOrDefault();
                    if (studentlocation != null)
                    {
                        var stud = Mapper.Map<StudentLocationModel>(studentlocation);
                        studentsloclist.Add(stud);
                    }
                }
                return studentsloclist;

            }
           
            
        }
        public BusLocationModel GetBusLocation(int parentid)
        {
            var studentid = this.studentRepository.GetBy(x => x.ParentId == parentid).SingleOrDefault();
            var busid = this.studentbusschedulRepository.GetBy(x => x.StudentId == studentid.StudentId).SingleOrDefault();
            var studentbuslocation = this.buslocationRepository.GetBy(x => x.BusId==busid.BusScheduleId).Last();
            return Mapper.Map<BusLocationModel>(studentbuslocation); ;
        }

        public List<BusLocationModel> GetAllBusLocation(int busid)
        {
            if(busid==0)
            {
                var buses = this.busRepository.GetAll();
                
                var buslocationlist = new List<BusLocationModel>();

                foreach (var bus in buses)
                {
                    var busdetail = this.busscheuleRepository.GetBy(x => x.BusId == bus.BusId).LastOrDefault();

                    var studentbuslocations = busdetail == null ? null : this.buslocationRepository.GetBy(x => x.BusId == busdetail.BusScheduleId).LastOrDefault();


                    if (studentbuslocations != null && busdetail != null)
                    {
                        var buslocation = Mapper.Map<BusLocationModel>(studentbuslocations);
                        buslocationlist.Add(buslocation);
                    }

                }



                return buslocationlist;
            }
            else
            {
             
                var buslocationlist = new List<BusLocationModel>();
                var busheduleid = this.busscheuleRepository.GetBy(x => x.BusId == busid).SingleOrDefault();
                var buslocation = this.buslocationRepository.GetBy(x => x.BusId == busheduleid.BusScheduleId).LastOrDefault();
                if (buslocation != null&& busheduleid!=null)
                {
                    var buslocations = Mapper.Map<BusLocationModel>(buslocation);
                    buslocationlist.Add(buslocations);
                }
               



                return buslocationlist;
            }
            
        }
    }
}
