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
	public class BusBusiness
	{
		private readonly IRepository<Bus> busRepository;//Connect User Repository
		private readonly IUnitOfWork unitOfWork;
		private List<StudentModel> students;

		public BusBusiness(IUnitOfWork unitOfWork)
		{
			this.busRepository = unitOfWork.GetRepository<IRepository<Bus>>();//Get User From Repository
			this.unitOfWork = unitOfWork;//Instantiate unitOfWork Variable
		}

		public BusModel AddBus(BusModel busModel)
		{
			var busEntity = new Bus()
			{
				BusName=busModel.BusName,
				CreatedBy = -1,
				CreatedOn = DateTime.UtcNow,
				UpdatedBy = -1,
				UpdatedOn = DateTime.UtcNow
			};

			this.busRepository.Add(busEntity);
			this.unitOfWork.Save();
			busModel.BusId = busEntity.BusId;

			return busModel;
		}


		public List<BusModel> Getbus()
		{
			var busEntity = this.busRepository.GetAll();

			var bus = new List<BusModel>();

			foreach (var b in busEntity)
			{
				bus.Add(new BusModel()
				{
					BusId = b.BusId,
					BusName = b.BusName,
					//StudentImg = student.StudentImg,
					//StudentAddress = student.StudentAddress,
					//StudentGender = student.StudentGender,
					//StudentDob = student.StudentDob,
					//FatherName = student.FatherName,
					//MotherName = student.MotherName,
					//ParentId = student.ParentId
				});
			}

			return bus;
		}


		public Int32 DeleteId(int id)
		{

			var busid = this.busRepository.GetBy(x => x.BusId == id).SingleOrDefault();
			busid.IsDeleted = true;
			this.unitOfWork.Save();
			return busid != null ? 0 : 1;

		}
		public BusModel BusGetById(int id)
		{
			try
			{
				var busdetails = this.busRepository.GetBy(x => x.BusId == id, x => x.BusSchedule).SingleOrDefault();
				var chec = Mapper.Map<BusModel>(busdetails);
				return chec;
			}
			catch (Exception e)
			{
				throw e;
			}

		}
		//public List<BusModel> BusScheduleUpdate(BusModel busModel)
		//{
			//var busupdate = this.busRepository.GetBy(x => x.BusId == busModel.BusId, x => x.BusSchedule).SingleOrDefault();
			//var model = new BusModel();
			//busupdate.BusName = busModel.BusName;
			//foreach(var item in busupdate.BusSchedule)
			//{
			//	model.BusSchedule.p
			//}
			//busupdate.BusSchedule.BusScheduleDriverName = busModel.BusSchedule.BusScheduleDriverName;
			//busupdate.StudentAddress = busModel.StudentAddress;
			//busupdate.StudentGender = busModel.StudentGender;
			//busupdate.StudentDob = busModel.StudentDob;
			//busupdate.FatherName = busModel.FatherName;
			//busupdate.MotherName = busModel.MotherName;
			//busupdate.User.UserName = busModel.User.UserName;
			//busupdate.User.UserEmail = busModel.User.UserEmail;
			//busupdate.User.UserMobileNo = busModel.User.UserMobileNo;


			//this.unitOfWork.Save();

			
			//var studentsEntity = this.studentRepository.GetAll();

			//var bus = new List<BusModel>();

			//foreach (var bus in busupdate)
			//{
			//	students.Add(new StudentModel()
			//	{
			//		StudentId = student.StudentId,
			//		StudentName = student.StudentName,
			//		StudentImg = student.StudentImg,
			//		StudentAddress = student.StudentAddress,
			//		StudentGender = student.StudentGender,
			//		StudentDob = student.StudentDob,
			//		FatherName = student.FatherName,
			//		MotherName = student.MotherName,
			//		ParentId = student.ParentId
			//	});
			//}

			//return students;
		//}
		}
}
