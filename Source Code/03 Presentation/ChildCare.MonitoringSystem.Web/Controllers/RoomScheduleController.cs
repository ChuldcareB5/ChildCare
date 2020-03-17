using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildCare.MonitoringSystem.Business;
using ChildCare.MonitoringSystem.Model;
using Microsoft.AspNetCore.Mvc;

namespace ChildCare.MonitoringSystem.Web.Controllers
{
    public class RoomScheduleController : Controller
    {
        private readonly RoomScheduleBusiness roomscheduleBusiness;

        //public IActionResult Index()
        //      {
        //          return View();
        //      }
        public RoomScheduleController(RoomScheduleBusiness roomscheduleBusiness)
        {
            this.roomscheduleBusiness = roomscheduleBusiness;
        }


        public ActionResult<Int32> RoomScheduleDeleteId(int id)
        {
            var students = this.roomscheduleBusiness.DeleteId(id);
            return students;
        }

        public ActionResult<StudentModel> AddStudentScheduleByBatch(RoomScheduleModel roomschedule, String batch)

        {
            var roomsche = this.roomscheduleBusiness.AddStudentScheduleByBatches(roomschedule, batch);
            return null;
        }


        public ActionResult<List<RoomScheduleModel>> GetRoomSchedule(int RoomId)
        {
            var rooms = this.roomscheduleBusiness.GetRoomSchedule(RoomId);
            return rooms;
        }

        public ActionResult<List<StudentModel>> GetRoomStudents(int RoomId, int RoomSheduleId)
        {
            var rooms = this.roomscheduleBusiness.GetRoomStudents(RoomId, RoomSheduleId);
            return rooms;

        }
    }
}