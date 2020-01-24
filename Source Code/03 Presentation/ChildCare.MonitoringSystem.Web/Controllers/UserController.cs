using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildCare.MonitoringSystem.Business;
using ChildCare.MonitoringSystem.Model;
using Microsoft.AspNetCore.Mvc;

namespace ChildCare.MonitoringSystem.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserBusiness userBusiness;

        public UserController(UserBusiness userBusiness)
        {
            this.userBusiness = userBusiness;
        }

        [HttpPost]
        public ActionResult<UserModel> AddParent([FromBody]UserModel studentmodel)
        {
            var user = this.userBusiness.AddParent(studentmodel);
            return user;
        }

        public ActionResult<UserModel> AddTeachert([FromBody]UserModel studentmodel)
        {
            var user = this.userBusiness.AddTeacher(studentmodel);
            return user;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult submit()
        {
            return View("index");
        }
    }
}