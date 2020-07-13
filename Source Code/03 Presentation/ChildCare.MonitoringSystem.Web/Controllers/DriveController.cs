using ChildCare.MonitoringSystem.Web.Models;
using GoogleDriveUploadMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;


namespace GoogleDriveUploadMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(StudentDetail file)
        {
            GoogleDriveAPIHelper.UplaodFileOnDrive(file);
            ViewBag.Success = "File Uploaded on Google Drive";
            return View();
        }
    }
}