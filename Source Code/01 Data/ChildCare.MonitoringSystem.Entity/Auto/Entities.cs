using ChildCare.MonitoringSystem.Core.Constraints;

namespace ChildCare.MonitoringSystem.Entity
{

    // Student
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.34.1.0")]
    public partial class Student: BaseEntity, IAuditable, ISoftDelete
    {
        public int StudentId { get; set; } // StudentId (Primary key)
        public string StudentName { get; set; } // StudentName (length: 100)
        public byte[] StudentImg { get; set; } // StudentImg (length: 2147483647)
        public string StudentAddress { get; set; } // StudentAddress (length: 200)
        public string StudentGender { get; set; } // StudentGender (length: 100)
        public System.DateTime StudentDob { get; set; } // StudentDob
        public string FatherName { get; set; } // FatherName (length: 100)
        public string MotherName { get; set; } // MotherName (length: 100)
        public int ParentId { get; set; } // ParentId
        public int CreatedBy { get; set; } // CreatedBy
        public System.DateTime CreatedOn { get; set; } // CreatedOn
        public int UpdatedBy { get; set; } // UpdatedBy
        public System.DateTime UpdatedOn { get; set; } // UpdatedOn
        public bool IsDeleted { get; set; } // IsDeleted

        // Foreign keys

        /// <summary>
        /// Parent User pointed by [Student].([ParentId]) (FK_Student_User)
        /// </summary>
        public virtual User User { get; set; } // FK_Student_User

        public Student()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // User
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.34.1.0")]
    public partial class User: BaseEntity, IAuditable, ISoftDelete
    {
        public int UserId { get; set; } // UserId (Primary key)
        public string UserName { get; set; } // UserName (length: 100)
        public string UserEmail { get; set; } // UserEmail (length: 100)
        public string UserPassword { get; set; } // UserPassword (length: 100)
        public string UserMobileNo { get; set; } // UserMobileNo (length: 12)
        public int CreatedBy { get; set; } // CreatedBy
        public System.DateTime CreatedOn { get; set; } // CreatedOn
        public int UpdatedBy { get; set; } // UpdatedBy
        public System.DateTime UpdatedOn { get; set; } // UpdatedOn
        public bool IsDeleted { get; set; } // IsDeleted

        // Reverse navigation

        /// <summary>
        /// Child Student where [Student].[ParentId] point to this entity (FK_Student_User)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Student> Student { get; set; } // Student.FK_Student_User

        public User()
        {
            Student = new System.Collections.Generic.List<Student>();
            InitializePartial();
        }

        partial void InitializePartial();
    }
}

