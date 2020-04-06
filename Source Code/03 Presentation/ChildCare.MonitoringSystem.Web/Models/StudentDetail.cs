using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildCare.MonitoringSystem.Web.Models
{
	public class StudentDetail
	{
		public int StudentId { get; set; }
		public string StudentName { get; set; } // StudentName (length: 100)
		public IFormFile StudentImg { get; set; } // StudentImg (length: 100)
		public string StudentAddress { get; set; } // StudentAddress (length: 200)
		public string StudentGender { get; set; } // StudentGender (length: 100)
		public DateTime StudentDob { get; set; } // StudentDob
		public string FatherName { get; set; } // FatherName (length: 100)
		public string MotherName { get; set; } // MotherName (length: 100)
		public int ParentId { get; set; } // ParentId(foreign key)
		public string Batch { get; set; } // Batch (length: 100)
		public string UserName { get; set; } // UserName (length: 100)
		public string UserEmail { get; set; } // UserEmail (length: 100)
		public string UserPassword { get; set; } // UserPassword (length: 100)
		public string UserMobileNo { get; set; } // UserMobileNo (length: 12)
        public string ErrorMessage { get; set; }
        public int Sheduleid { get; set; }
        public string Toaddress { get; set; }
        public string Fromaddress { get; set; }
    }
}
