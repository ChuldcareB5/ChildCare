using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildCare.MonitoringSystem.Web.Models
{
    public class LoginViewModel
    {
        public string ErrorMessage { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
