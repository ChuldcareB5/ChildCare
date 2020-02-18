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
     public class RoomScheduleBuisness
    {
        private readonly IRepository<RoomSchedule> roomscheduleRepository;//Connect User Repository
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Student> studentRepository;//Connect User Repository


        public RoomScheduleBuisness(IUnitOfWork unitOfWork)
        {
            this.roomscheduleRepository = unitOfWork.GetRepository<IRepository<RoomSchedule>>();//Get User From Repository
            this.studentRepository = unitOfWork.GetRepository<IRepository<Student>>();//Get User From Repository
            this.unitOfWork = unitOfWork;//Instantiate unitOfWork Variable
        }
        public RoomScheduleModel AddStudentScheduleByBatches(RoomScheduleModel roomschedule,String batch)
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
                this.roomscheduleRepository.Add(studentscheduleentity);
                this.unitOfWork.Save();
            }
          
            
            return null;
        }
        public List<RoomScheduleModel> GetRoomSchedule(int RoomId)
        {
            try {

                var room1 = this.roomscheduleRepository.GetBy(x => x.RoomId == RoomId);
                //var rooms1 = this.roomscheduleRepository.GetBy(x => x.RoomId == RoomId).GroupBy(x => x.RoomScheduleTime).ToList();
                //var room2 = this.roomscheduleRepository.GetBy(x => x.RoomId == RoomId).Select(x => x.RoomScheduleTime);
                //var room3 = this.roomscheduleRepository.GetBy(x => x.RoomId == RoomId).Select(x=>x.RoomScheduleTime).Distinct();
                ////var room4 = this.roomscheduleRepository.GetBy(x => x.RoomId == RoomId).Select(x => ).Distinct();
                //var room3 = this.roomscheduleRepository.GetBy(x => x.RoomId == RoomId).SelectMany(x => x);
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
                    //rooms.Add(new RoomScheduleModel()
                    //{
                    //    RoomScheduleId = room.RoomId,
                    //    TeacherId = room.TeacherId,
                    //    RoomScheduleDate = room.RoomScheduleDate,
                    //    RoomScheduleTime = room.RoomScheduleTime,
                    //    RoomScheduleSubject = room.RoomScheduleSubject,
                    //    RoomId = room.RoomId,
                    //});
                }

                //foreach (var item in rooms2)
                //{

                //        var lists = new RoomScheduleModel()
                //        {
                //            RoomScheduleId = item.First().RoomScheduleId,
                //            TeacherId = item.First().TeacherId,
                //            RoomScheduleDate = item.First().RoomScheduleDate,
                //            RoomScheduleTime = item.First().RoomScheduleTime,
                //            RoomScheduleSubject = item.First().RoomScheduleSubject,
                //            RoomId = item.First().RoomId,
                //        };
                //        rooms.Add(lists);

                //}
                return roo;
            }
           catch(Exception e)
            {
                throw e;
            }

            //var roomscheduleentity = this.roomscheduleRepository.GetBy(x => x.RoomId == RoomId).Distinct();
           
            //var roomEntity = this.roomscheduleRepository.GetAll().GroupBy(x => x.RoomScheduleTime).Where(g => g).Select(g => g.First());


            //foreach (var room in rooms1)
            //{
            //    rooms.Add(new RoomScheduleModel()
            //    {
            //        RoomScheduleId = rooms1.,
            //        TeacherId = room.TeacherId,
            //        RoomScheduleDate = room.RoomScheduleDate,
            //        RoomScheduleTime = room.RoomScheduleTime,
            //        RoomScheduleSubject = room.RoomScheduleSubject,
            //        StudentId = room.StudentId,
            //        RoomId = room.RoomId,
            //    });
            //}

            //return null;
        }
        ///GetRoomStudents
        public List<StudentModel> GetRoomStudents(int RoomId,int RoomSheduleId)
        {
            try
            {
                var times = this.roomscheduleRepository.GetBy(x => x.RoomId == RoomId && x.RoomScheduleId == RoomSheduleId).First();
              
                var students = this.roomscheduleRepository.GetBy(x => x.RoomId == RoomId && x.RoomScheduleTime==times.RoomScheduleTime,x=>x.Student);

               
                var room = new List<StudentModel>();
                foreach (var student in students)
                {
                    var studentdetails = this.studentRepository.GetBy(x => x.StudentId == student.StudentId).First();
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
                        Batch=studentdetails.Batch,

                    });
                }
                return room;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Int32 DeleteId(int id)
        {
            var roomscheduleid = this.roomscheduleRepository.GetBy(x => x.RoomScheduleId == id).SingleOrDefault();
            roomscheduleid.IsDeleted = true;
            this.unitOfWork.Save();
            return roomscheduleid != null ? 0 : 1;

        }
    }
}
