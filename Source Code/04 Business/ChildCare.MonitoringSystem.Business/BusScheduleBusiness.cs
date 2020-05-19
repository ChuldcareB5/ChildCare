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
	public class BusScheduleBusiness
	{
		private readonly IRepository<BusSchedule> busScheduleRepository;//Connect User Repository
        private readonly IRepository<Bus> busRepository;//Connect Bus Repository
        private readonly IUnitOfWork unitOfWork;

		public BusScheduleBusiness(IUnitOfWork unitOfWork)
		{
			this.busScheduleRepository = unitOfWork.GetRepository<IRepository<BusSchedule>>();//Get User From Repository
            this.busRepository = unitOfWork.GetRepository<IRepository<Bus>>();//Get User From Repository
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

        public int DeleteBusSchedule(int id)
        {
            var busdetails = this.busScheduleRepository.GetBy(x => x.BusId == id).SingleOrDefault();
            busdetails.IsDeleted = true;
            
            this.unitOfWork.Save();

            return busdetails.BusScheduleId; ;
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


		public List<BusModel> Getbus()
		{
			try
			{
				var busEntity = this.busRepository.GetAll();
				var result=Mapper.Map<List<BusModel>>(busEntity);
				return result;

			}
			catch(Exception e)
			{
				throw e;
			}
			
			//var bus = new List<BusSchedule>();

			//foreach (var b in busEntity)
			//{
			//	bus.Add(new BusScheduleModel()
			//	{
			//		BusId = b.BusId,
			//		BusName = b.Bus.BusName,

			//		BusScheduleId=b.BusScheduleId,
			//		ToBusSchedule=b.ToBusSchedule,
			//		FromBusSchedule=b.FromBusSchedule,
			//		BusScheduleDate=b.BusScheduleDate,
			//		BusScheduleTime=b.BusScheduleTime,
			//		BusScheduleDriverName=b.BusScheduleDriverName,

			//		//StudentImg = student.StudentImg,
			//		//StudentAddress = student.StudentAddress,
			//		//StudentGender = student.StudentGender,
			//		//StudentDob = student.StudentDob,
			//		//FatherName = student.FatherName,
			//		//MotherName = student.MotherName,
			//		//ParentId = student.ParentId
			//	});
			//}

			//return bus;
		}


		public BusScheduleModel BusGetById(int id)
		{
			try
			{
				var busdetails = this.busScheduleRepository.GetBy(x => x.BusScheduleId == id, x => x.Bus).SingleOrDefault();
				var chec = Mapper.Map<BusScheduleModel>(busdetails);

				return chec;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public BusScheduleModel BusScheduleUpdate(BusScheduleModel busScheduleModel)
		{
			var busupdate = this.busScheduleRepository.GetBy(x => x.BusScheduleId == busScheduleModel.BusScheduleId, x => x.Bus).SingleOrDefault();

			busupdate.BusScheduleDriverName = busScheduleModel.BusScheduleDriverName;
			busupdate.ToBusSchedule = busScheduleModel.ToBusSchedule;
			busupdate.FromBusSchedule = busScheduleModel.FromBusSchedule;
			busupdate.BusScheduleTime = busScheduleModel.BusScheduleTime;
			busupdate.BusScheduleDate = busScheduleModel.BusScheduleDate;
			busupdate.Bus.BusName = busScheduleModel.Bus.BusName;

			this.unitOfWork.Save();

			return busScheduleModel;

		}

        public BusScheduleModel GetBusDetailsById(int id)
        {
            try
            {
                var busdetails = this.busScheduleRepository.GetBy(x => x.BusId == id).SingleOrDefault();
                var chec = Mapper.Map<BusScheduleModel>(busdetails);
                return chec;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
