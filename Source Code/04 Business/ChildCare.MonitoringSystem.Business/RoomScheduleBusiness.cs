using ChildCare.MonitoringSystem.Core.Constraints;
using ChildCare.MonitoringSystem.Entity;
using ChildCare.MonitoringSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChildCare.MonitoringSystem.Business
{
	public class RoomScheduleBusiness
	{
		//private readonly IRepository<Room> roomRepository;//Connect user Repository
		private readonly IRepository<RoomSchedule> roomScheduleRepository;
		private readonly IUnitOfWork unitOfWork;
		

		public RoomScheduleBusiness(IUnitOfWork unitOfWork)
		{
			this.roomScheduleRepository = unitOfWork.GetRepository<IRepository<RoomSchedule>>();//Get User From Repository
			this.unitOfWork = unitOfWork;//Instantiate unitOfWork Variable
		}



		public Int32 DeleteId(int id)
		{

			var roomscheduleid = this.roomScheduleRepository.GetBy(x => x.RoomScheduleId == id).SingleOrDefault();
			roomscheduleid.IsDeleted = true;
			this.unitOfWork.Save();
			return roomscheduleid != null ? 0 : 1;

		}
	}
}
