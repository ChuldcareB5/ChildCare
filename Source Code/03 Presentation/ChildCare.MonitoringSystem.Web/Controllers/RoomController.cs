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
	//[Authorize(Roles = "1")]
	public class RoomController : Controller
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

		public ActionResult<List<RoomModel>> GetRoom()
		{
			var rooms = this.roomBusiness.GetRoom();
			return rooms;
		}

		public ActionResult<List<RoomScheduleModel>> GetRoomSchedule()
		{
			var roomschedules = this.roomBusiness.GetRoomSchedule();
			return roomschedules;
		}


		public ActionResult<Int32> RoomDeleteId(int id)
		{
			var students = this.roomBusiness.DeleteId(id);
			return students;
		}


		//public IActionResult RoomSchedule()
		//{
		//	return View();
		//}


	}
}
