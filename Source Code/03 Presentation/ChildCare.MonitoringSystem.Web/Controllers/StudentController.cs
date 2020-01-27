using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChildCare.MonitoringSystem.Web.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult submit()
        {
            return View("Homepage");
        }
    }
}