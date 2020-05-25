using AutoMapper;
using ChildCare.MonitoringSystem.Core.Constraints;
using ChildCare.MonitoringSystem.Entity;
using ChildCare.MonitoringSystem.Model;
using ChildCare.MonitoringSystem.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChildCare.MonitoringSystem.Business
{
	public class BusBusiness
	{
		private readonly IRepository<Bus> busRepository;//Connect User Repository
		private readonly IRepository<BusSchedule> busschedulerepository;
		private readonly IRepository<BusLocation> buslocationrepository;
		private readonly IUnitOfWork unitOfWork;
		private List<StudentModel> students;

		public BusBusiness(IUnitOfWork unitOfWork)
		{
			this.busRepository = unitOfWork.GetRepository<IRepository<Bus>>();//Get User From Repository
			this.busschedulerepository = unitOfWork.GetRepository<IRepository<BusSchedule>>();
			this.buslocationrepository = unitOfWork.GetRepository<IRepository<BusLocation>>();
			this.unitOfWork = unitOfWork;//Instantiate unitOfWork Variable
		}

		public BusModel AddBus(BusModel busModel)
		{
			var busEntity = new Bus()
			{
				BusName=busModel.BusName,
                BusDriverName=busModel.BusDriverName,
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

		public Int32 DeleteId(int id)
		{

			var busid = this.busRepository.GetBy(x => x.BusId == id).SingleOrDefault();
			busid.IsDeleted = true;
			this.unitOfWork.Save();
			return busid != null ? 0 : 1;

		}
		
		public List<BusModel> BusScheduleUpdate(BusModel busModel)
		{
			var busupdate = this.busRepository.GetBy(x => x.BusId == busModel.BusId, x => x.BusSchedule).SingleOrDefault();
			//var model = new BusModel();
			//busupdate.BusName = busModel.BusName;
			//{
			//	model.BusSchedule.p
			//}	foreach (var item in busupdate.BusSchedule)
		
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
			return null;


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
		}
        public BusModel BusGetById(int id)
        {
            try
            {
                var busdetails = this.busRepository.GetBy(x => x.BusId == id, x => x.BusSchedule).SingleOrDefault();
               var chec=Mapper.Map<BusModel>(busdetails);
                return chec;
            }
            catch(Exception e)
            {
                throw e;
            }
           
        }

		public ArrayList getBusDestination()
		{
			var busEntity = this.busschedulerepository.GetAll();


			ArrayList ms = new ArrayList();
			foreach (var bus in busEntity)
			{

				if (ms.Contains(bus.ToBusSchedule.ToString()))
				{
					continue;
				}
				else
				{
					ms.Add(bus.ToBusSchedule);
				}

			}
			return ms;
		} 

		public BusModel UpdateBusSchedule(BusModel busModel)
        {
            var busupdate = this.busRepository.GetBy(x => x.BusId == busModel.BusId, x => x.BusSchedule).SingleOrDefault();

            this.unitOfWork.Save();

            return busModel;

        }


        public List<BusScheduleModel> getbusshedule(String To)
		{
			var busschedule = this.busschedulerepository.GetBy(x => x.ToBusSchedule == To);
			var buses = new List<BusScheduleModel>();
			foreach(var Bus in busschedule)
			{
				var bus=Mapper.Map<BusScheduleModel>(Bus);
				buses.Add(bus);
			}
			return buses;
		}

        public ArrayList getBusIds()
        {
            var busEntity = this.busRepository.GetAll();

            ArrayList busto = new ArrayList();
            foreach (var bus in busEntity)
            {
				var busscheduleid = this.busschedulerepository.GetBy(x => x.BusId == bus.BusId).SingleOrDefault();
				var buslocation = busscheduleid != null ? this.buslocationrepository.GetBy(x => x.BusId == bus.BusId).SingleOrDefault() : null;
				if (buslocation != null)
				{
					busto.Add(bus.BusId);
				}
            }
            return busto;
        }

		public ArrayList BusGetByIdCompareWithBusSchedule()
		{
			var busEntity = this.busschedulerepository.GetBy(x=>x.IsDeleted==false);

			ArrayList busto = new ArrayList();
			foreach (var bus in busEntity)
			{
				//var busscheduleid = this.busschedulerepository.GetBy(x => x.BusId == bus.BusId).SingleOrDefault();
				//if (busscheduleid != null)
				//{
					busto.Add(bus.BusId);
				//}
			}
			return busto;
		}

        public ArrayList GetBusWithNoSchedule()
        {
            var busEntity = this.busRepository.GetAll();
            

            ArrayList busto = new ArrayList();
            foreach (var bus in busEntity)
            {
                var busid = this.busschedulerepository.GetBy(x => x.BusId == bus.BusId && x.IsDeleted==false);
                if (busid.Count == 0)
                {
                    busto.Add(bus.BusId);
                }
            }
            return busto;

        }


    }
}
