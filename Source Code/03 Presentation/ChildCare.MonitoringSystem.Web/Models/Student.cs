using System;
using System.Collections.Generic;

namespace ChildCare.MonitoringSystem.Web.Models
{
    public partial class Student
    {
        public Student()
        {
            RoomSchedule = new HashSet<RoomSchedule>();
            StudentBusSchedule = new HashSet<StudentBusSchedule>();
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public byte[] StudentImg { get; set; }
        public string StudentAddress { get; set; }
        public string StudentGender { get; set; }
        public DateTime StudentDob { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public int ParentId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }

        public User Parent { get; set; }
        public ICollection<RoomSchedule> RoomSchedule { get; set; }
        public ICollection<StudentBusSchedule> StudentBusSchedule { get; set; }
    }
}
