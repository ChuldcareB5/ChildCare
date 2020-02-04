using ChildCare.MonitoringSystem.Business;
using ChildCare.MonitoringSystem.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildCare.MonitoringSystem.Web.Controllers
{
    [Authorize(Roles = "2")]
    public class RoomController:Controller
    {
        private readonly RoomBusiness roomBusiness;

        public RoomController(RoomBusiness roomBusiness)
        {
            this.roomBusiness = roomBusiness;
        }

        public ActionResult<Int32> AddRoom(RoomModel roomModel)
        {
            var room = this.roomBusiness.AddRoom(roomModel);
            var userId = room.RoomId;
            return room.RoomId; ;
        }
    }
}
