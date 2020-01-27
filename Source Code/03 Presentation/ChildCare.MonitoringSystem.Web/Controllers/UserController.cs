using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildCare.MonitoringSystem.Business;
using ChildCare.MonitoringSystem.Model;
using Microsoft.AspNetCore.Mvc;

namespace ChildCare.MonitoringSystem.Web.Controllers
{
    public class UserController
    {
        private readonly UserBusiness userBusiness;
        public UserController(UserBusiness userBusiness)
        {
            this.userBusiness = userBusiness;
        }
        public ActionResult<UserModel> AddTeacher(UserModel studentModel)
        {
            var user = this.userBusiness.AddTeacher(studentModel);
            return user;
        }
    }
}
