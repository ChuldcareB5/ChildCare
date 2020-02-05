using System;
using System.Collections;
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
        private readonly RoomScheduleBuisness roomScheduleBuisness;
        public RoomScheduleController(RoomScheduleBuisness roomScheduleBuisness)
        {
            this.roomScheduleBuisness = roomScheduleBuisness;
        }
        public ActionResult<StudentModel> AddStudentScheduleByBatch(RoomScheduleModel roomschedule, String batch)
        {
            var roomsche = this.roomScheduleBuisness.AddStudentScheduleByBatches(roomschedule, batch);
            return null;
        }
     

        public ActionResult<List<RoomScheduleModel>> GetRoomSchedule(int RoomId)
        {
            var rooms = this.roomScheduleBuisness.GetRoomSchedule(RoomId);
            return rooms;
        }
    }
}