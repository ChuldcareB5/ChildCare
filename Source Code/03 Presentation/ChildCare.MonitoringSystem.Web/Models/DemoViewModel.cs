using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildCare.MonitoringSystem.Web.Models
{
    public class DemoViewModel
    {
        public string Name { get; set; }

        public IFormFile ProfilePic { get; set; }
    }
}
