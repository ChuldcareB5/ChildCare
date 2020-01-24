using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildCare.MonitoringSystem.Entity;
using ChildCare.MonitoringSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChildCare.MonitoringSystem.Web.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult submit(StudentModel studentmodel)
        //{
        //    //return StudentRepository.Add(student);
        //    return 
        //}
    }
}