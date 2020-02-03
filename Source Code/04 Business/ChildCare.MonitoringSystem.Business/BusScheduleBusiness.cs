﻿using ChildCare.MonitoringSystem.Core.Constraints;
using ChildCare.MonitoringSystem.Entity;
using ChildCare.MonitoringSystem.Model;
using ChildCare.MonitoringSystem.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChildCare.MonitoringSystem.Business
{
	public class BusScheduleBusiness
	{
		private readonly IRepository<BusSchedule> busScheduleRepository;//Connect User Repository
		private readonly IUnitOfWork unitOfWork;

		public BusScheduleBusiness(IUnitOfWork unitOfWork)
		{
			this.busScheduleRepository = unitOfWork.GetRepository<IRepository<BusSchedule>>();//Get User From Repository
			this.unitOfWork = unitOfWork;//Instantiate unitOfWork Variable
		}
		public BusScheduleModel AddBusSchedule(BusScheduleModel busScheduleModel)
		{
			var busScheduleEntity = new BusSchedule()
			{
				BusScheduleDriverName = busScheduleModel.BusScheduleDriverName,
				ToBusSchedule = busScheduleModel.ToBusSchedule,
				FromBusSchedule=busScheduleModel.FromBusSchedule,
				BusScheduleTime=busScheduleModel.BusScheduleTime,
				BusScheduleDate=busScheduleModel.BusScheduleDate,
				BusId = busScheduleModel.BusId,
				CreatedBy = -1,
				CreatedOn = DateTime.UtcNow,
				UpdatedBy = -1,
				UpdatedOn = DateTime.UtcNow
			};

			this.busScheduleRepository.Add(busScheduleEntity);
			this.unitOfWork.Save();
			busScheduleModel.BusScheduleId = busScheduleEntity.BusScheduleId;
			return busScheduleModel;
		}


		public List<BusScheduleModel> GetbusSchedule()
		{
			var busScheduleEntity = this.busScheduleRepository.GetAll();

			var busSchedule = new List<BusScheduleModel>();

			//foreach (var b in busScheduleEntity)
			//{
			//	bus.Add(new BusModel()
			//	{
			//		BusId = b.BusId,
			//		BusName = b.BusName,
			//		//StudentImg = student.StudentImg,
			//		//StudentAddress = student.StudentAddress,
			//		//StudentGender = student.StudentGender,
			//		//StudentDob = student.StudentDob,
			//		//FatherName = student.FatherName,
			//		//MotherName = student.MotherName,
			//		//ParentId = student.ParentId
			//	});
			//}

			return busSchedule;
		}
	}
}