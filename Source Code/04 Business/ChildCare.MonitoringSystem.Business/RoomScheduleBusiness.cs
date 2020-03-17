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
	public class RoomScheduleBusiness
	{
		//private readonly IRepository<Room> roomRepository;//Connect user Repository
		private readonly IRepository<RoomSchedule> roomScheduleRepository;
		private readonly IRepository<Student> studentRepository;//Connect student Repository

		private readonly IUnitOfWork unitOfWork;
		

		public RoomScheduleBusiness(IUnitOfWork unitOfWork)
		{
			this.roomScheduleRepository = unitOfWork.GetRepository<IRepository<RoomSchedule>>();//Get User From Repository
			this.studentRepository = unitOfWork.GetRepository<IRepository<Student>>();
			this.unitOfWork = unitOfWork;//Instantiate unitOfWork Variable
		}



		public Int32 DeleteId(int id)
		{

			var roomscheduleid = this.roomScheduleRepository.GetBy(x => x.RoomScheduleId == id).SingleOrDefault();
			roomscheduleid.IsDeleted = true;
			this.unitOfWork.Save();
			return roomscheduleid != null ? 0 : 1;

		}



		public RoomScheduleModel AddStudentScheduleByBatches(RoomScheduleModel roomschedule, String batch)
		{
			var batchstudents = this.studentRepository.GetBy(x => x.Batch == batch);
			foreach (var student in batchstudents)
			{
				var studentscheduleentity = new RoomSchedule()
				{
					TeacherId = roomschedule.TeacherId,
					RoomScheduleDate = roomschedule.RoomScheduleDate,
					RoomScheduleTime = roomschedule.RoomScheduleTime,
					RoomScheduleSubject = roomschedule.RoomScheduleSubject,
					StudentId = student.StudentId,
					RoomId = roomschedule.RoomId,
				};
				this.roomScheduleRepository.Add(studentscheduleentity);
				this.unitOfWork.Save();
			}


			return null;
		}
		public List<RoomScheduleModel>  GetRoomSchedule(int RoomId)
		{
			try
			{

				var room1 = this.roomScheduleRepository.GetBy(x => x.RoomId == RoomId);
				var rooms = new List<String>();
				var roo = new List<RoomScheduleModel>();
				foreach (var room in room1)
				{
					if (rooms.Contains(room.RoomScheduleTime.ToString()))
					{
						continue;
					}
					else
					{
						roo.Add(new RoomScheduleModel()
						{
							RoomScheduleId = room.RoomScheduleId,
							TeacherId = room.TeacherId,
							RoomScheduleDate = room.RoomScheduleDate,
							RoomScheduleTime = room.RoomScheduleTime,
							RoomScheduleSubject = room.RoomScheduleSubject,
							RoomId = room.RoomId,

						});
						rooms.Add(room.RoomScheduleTime.ToString());
					}

				}


				return roo;
			}
			catch (Exception e)
			{
				throw e;
			}

		}
		///GetRoomStudents
		public List<StudentModel> GetRoomStudents(int RoomId, int RoomSheduleId)
		{
			try  
			{
				var times = this.roomScheduleRepository.GetBy(x => x.RoomId == RoomId && x.RoomScheduleId == RoomSheduleId).First();

				var students = this.roomScheduleRepository.GetBy(x => x.RoomId == RoomId && x.RoomScheduleTime == times.RoomScheduleTime, x => x.Student);


				var room = new List<StudentModel>();
				foreach (var student in students)
				{
					var studentdetails = this.studentRepository.GetBy(x => x.StudentId == student.StudentId).SingleOrDefault();
					room.Add(new StudentModel()
					{
						StudentId = studentdetails.StudentId,
						StudentName = studentdetails.StudentName,
						StudentImg = studentdetails.StudentImg,
						StudentAddress = studentdetails.StudentAddress,
						StudentGender = studentdetails.StudentGender,
						StudentDob = studentdetails.StudentDob,
						FatherName = studentdetails.FatherName,
						MotherName = studentdetails.MotherName,
						ParentId = studentdetails.ParentId,
						Batch = studentdetails.Batch,

					});
				}
				return room;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

	}
}
