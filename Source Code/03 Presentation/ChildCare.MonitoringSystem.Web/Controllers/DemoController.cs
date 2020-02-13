using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChildCare.MonitoringSystem.Web.Models;
using ChildCare.MonitoringSystem.Model;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ChildCare.MonitoringSystem.Web.Controllers
{
    public class DemoController : Controller
    {
        private static List<string> uploadedImages = new List<string>();

        private readonly IHostingEnvironment environment;
        private readonly string profilePicPath = "profilepics";
        public DemoController(IHostingEnvironment environment)
        {
            this.environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveDemo(DemoViewModel demoModel)
        {
            string imageName = Guid.NewGuid().ToString() + Path.GetExtension(demoModel.ProfilePic.FileName);

            //Get url To Save
            string savePath = Path.Combine(environment.WebRootPath, this.profilePicPath, imageName);

            using (var stream = new FileStream(savePath, FileMode.Create))
            {
                demoModel.ProfilePic.CopyTo(stream);
            }

            uploadedImages.Add(imageName);

            return View(nameof(Index));
        }

        public IActionResult ViewImage()
        {
            var firstImage = uploadedImages.FirstOrDefault();

            if (firstImage != null)
            {
                var model = new DemoDataViewModel()
                {
                    ProfilePicPath = $"/{this.profilePicPath}/{firstImage}"
                };

                return View(model);
            }

            return View(new DemoDataViewModel());
        }
    }
}
