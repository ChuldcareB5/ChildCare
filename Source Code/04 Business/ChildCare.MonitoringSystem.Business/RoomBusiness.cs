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
    public class RoomBusiness
    {
        private readonly IRepository<Room> roomRepository;//Connect user Repository
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<RoomSchedule> roomScheduleRepository;
        private readonly IRepository<RoomVideo> roomvideorepository;
        
        public RoomBusiness(IUnitOfWork unitOfWork)
        {
            this.roomRepository = unitOfWork.GetRepository<IRepository<Room>>();//Get User From Repository
            this.unitOfWork = unitOfWork;//Instantiate unitOfWork Variable
            this.roomScheduleRepository = unitOfWork.GetRepository<IRepository<RoomSchedule>>();
            this.roomvideorepository=unitOfWork.GetRepository<IRepository<RoomVideo>>();
        }

        public RoomModel AddRoom(RoomModel roomModel)
        {
            var roomEntity = new Room()
            {
                RoomName = roomModel.RoomName,
                CreatedBy = -1,
                CreatedOn = DateTime.UtcNow,
                UpdatedBy = -1,
                UpdatedOn = DateTime.UtcNow
            };


            this.roomRepository.Add(roomEntity);
            this.unitOfWork.Save();
            roomModel.RoomId = roomEntity.RoomId;

            return roomModel;
        }

        public List<RoomModel> GetRoom()
        {
            var roomEntity = this.roomRepository.GetAll();

            var rooms = new List<RoomModel>();

            foreach (var room in roomEntity)
            {
                rooms.Add(new RoomModel()
                {
                    RoomId = room.RoomId,
                    RoomName = room.RoomName,
                });
            }

            return rooms;
        }

        public List<RoomScheduleModel> GetRoomSchedule()
        {
            //var roomEntity = this.roomScheduleRepository.GetAll().GroupBy(x=>x.RoomScheduleTime);
            //return AutoMapper.Mapper.Map<List<RoomScheduleModel>>(roomEntity);
            var roomEntity = this.roomScheduleRepository.GetAll();
            var rooms = new List<RoomScheduleModel>();

            foreach (var room in roomEntity)
            {
                rooms.Add(new RoomScheduleModel()
                {
                    RoomScheduleId = room.RoomScheduleId,
                    TeacherId = room.TeacherId,
                    RoomScheduleDate = room.RoomScheduleDate,
                    RoomScheduleTime = room.RoomScheduleTime,
                    RoomScheduleSubject = room.RoomScheduleSubject,
                    StudentId = room.StudentId,
                    RoomId = room.RoomId,
                });
            }

            return rooms;
        }

         public Int32 Updatedvideoid(string id)
        {
            var roomvideoEntity = new RoomVideo()
            {

                RoomVideoUrlId = id,
                RoomId=1,
                CreatedBy = -1,
                CreatedOn = DateTime.UtcNow,
                UpdatedBy = -1,
                UpdatedOn = DateTime.UtcNow
            };


            this.roomvideorepository.Add(roomvideoEntity);
            this.unitOfWork.Save();
            return 1;
        }
		public Int32 DeleteId(int id)
		{

			var roomid = this.roomRepository.GetBy(x => x.RoomId == id).SingleOrDefault();
			roomid.IsDeleted = true;
			this.unitOfWork.Save();
			return roomid != null ? 0 : 1;

		}
        public string Updatedpath(int id,string paths)
        {
            var roomid = this.roomvideorepository.GetBy(x => x.RoomVideoId == id).SingleOrDefault();
            roomid.Path = paths;
            this.unitOfWork.Save();
            return null;
        }
        public List<string> GetAllRoomvideos()
        {
            var urlid = this.roomvideorepository.GetAll();
            var roomlist = new List<string>();
            foreach (var url in urlid)
            {
                roomlist.Add(url.Path);


            }
            return roomlist;
        }
        public List<RoomVideoModel> GetRoomvideourlId()
        {
            var urllist = new List<RoomVideoModel>();    
            var urlid = this.roomvideorepository.GetAll();
            foreach(var url in urlid)
            {
                if(url.Path==null)
                {
                    urllist.Add(new RoomVideoModel()
                    {
                        RoomVideoId = url.RoomVideoId,
                        RoomVideoUrlId = url.RoomVideoUrlId,
                    });
                }
                else
                {
                    continue;
                }
               
               
            }
            return urllist;
        }
        //////////////////////////////////////////
       
	}
}