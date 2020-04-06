using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChildCare.MonitoringSystem.Model
{
	public class StudentModel
	{
        public int StudentId { get; set; } // StudentId (Primary key)
        public string StudentName { get; set; } // StudentName (length: 100)
        public string StudentImg { get; set; } // StudentImg (length: 100)
        public string StudentAddress { get; set; } // StudentAddress (length: 200)
        public string StudentGender { get; set; } // StudentGender (length: 100)
        public System.DateTime StudentDob { get; set; } // StudentDob
        public string FatherName { get; set; } // FatherName (length: 100)
        public string MotherName { get; set; } // MotherName (length: 100)
        public int ParentId { get; set; } // ParentId
        public string Batch { get; set; } // Batch (length: 100)
        public int BusId { get; set; } // BusId (length: 100)

		public UserModel Parent { get; set; } // FK_Student_User
	}
}
