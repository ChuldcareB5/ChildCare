using ChildCare.MonitoringSystem.Core.Constraints;
using ChildCare.MonitoringSystem.Entity;
using ChildCare.MonitoringSystem.Model;
using ChildCare.MonitoringSystem.Repository;
using System;
using System.Collections.Generic;
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
	}
}
