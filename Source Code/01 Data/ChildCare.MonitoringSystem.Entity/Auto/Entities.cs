using ChildCare.MonitoringSystem.Core.Constraints;

namespace ChildCare.MonitoringSystem.Entity
{

    // Bus
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.34.1.0")]
    public partial class Bus: BaseEntity, IAuditable, ISoftDelete
    {
        public int BusId { get; set; } // BusId (Primary key)
        public string BusName { get; set; } // BusName (length: 100)
        public string BusDriverName { get; set; } // BusDriverName (length: 100)
        public int CreatedBy { get; set; } // CreatedBy
        public System.DateTime CreatedOn { get; set; } // CreatedOn
        public int UpdatedBy { get; set; } // UpdatedBy
        public System.DateTime UpdatedOn { get; set; } // UpdatedOn
        public bool IsDeleted { get; set; } // IsDeleted

        // Reverse navigation

        /// <summary>
        /// Child BusLocation where [BusLocation].[BusId] point to this entity (FK_BusLocation_Bus)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<BusLocation> BusLocation { get; set; } // BusLocation.FK_BusLocation_Bus
        /// <summary>
        /// Child BusSchedule where [BusSchedule].[BusId] point to this entity (FK_BusSchedule_Bus)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<BusSchedule> BusSchedule { get; set; } // BusSchedule.FK_BusSchedule_Bus

        public Bus()
        {
            BusLocation = new System.Collections.Generic.List<BusLocation>();
            BusSchedule = new System.Collections.Generic.List<BusSchedule>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BusLocation
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.34.1.0")]
    public partial class BusLocation: BaseEntity, IAuditable, ISoftDelete
    {
        public int BusLocationId { get; set; } // BusLocationId (Primary key)
        public int BusId { get; set; } // BusId
        public int BusScheduleId { get; set; } // BusScheduleId
        public System.DateTime LocationTime { get; set; } // LocationTime
        public double Longitute { get; set; } // Longitute
        public double Latitude { get; set; } // Latitude
        public int CreatedBy { get; set; } // CreatedBy
        public System.DateTime CreatedOn { get; set; } // CreatedOn
        public int UpdatedBy { get; set; } // UpdatedBy
        public System.DateTime UpdatedOn { get; set; } // UpdatedOn
        public bool IsDeleted { get; set; } // IsDeleted

        // Foreign keys

        /// <summary>
        /// Parent Bus pointed by [BusLocation].([BusId]) (FK_BusLocation_Bus)
        /// </summary>
        public virtual Bus Bus { get; set; } // FK_BusLocation_Bus

        /// <summary>
        /// Parent BusSchedule pointed by [BusLocation].([BusScheduleId]) (FK_BusLocation_BusSchedule)
        /// </summary>
        public virtual BusSchedule BusSchedule { get; set; } // FK_BusLocation_BusSchedule

        public BusLocation()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // BusSchedule
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.34.1.0")]
    public partial class BusSchedule: BaseEntity, IAuditable, ISoftDelete
    {
        public int BusScheduleId { get; set; } // BusScheduleId (Primary key)
        public string BusScheduleDriverName { get; set; } // BusScheduleDriverName (length: 100)
        public string ToBusSchedule { get; set; } // ToBusSchedule (length: 100)
        public string FromBusSchedule { get; set; } // FromBusSchedule (length: 100)
        public System.TimeSpan BusScheduleTime { get; set; } // BusScheduleTime
        public System.DateTime BusScheduleDate { get; set; } // BusScheduleDate
        public int BusId { get; set; } // BusId
        public int CreatedBy { get; set; } // CreatedBy
        public System.DateTime CreatedOn { get; set; } // CreatedOn
        public int UpdatedBy { get; set; } // UpdatedBy
        public System.DateTime UpdatedOn { get; set; } // UpdatedOn
        public bool IsDeleted { get; set; } // IsDeleted

        // Reverse navigation

        /// <summary>
        /// Child BusLocation where [BusLocation].[BusScheduleId] point to this entity (FK_BusLocation_BusSchedule)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<BusLocation> BusLocation { get; set; } // BusLocation.FK_BusLocation_BusSchedule
        /// <summary>
        /// Child StudentBusSchedule where [StudentBusSchedule].[BusScheduleId] point to this entity (FK_StudentBusSchedule_BusSchedule1)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<StudentBusSchedule> StudentBusSchedule { get; set; } // StudentBusSchedule.FK_StudentBusSchedule_BusSchedule1

        // Foreign keys

        /// <summary>
        /// Parent Bus pointed by [BusSchedule].([BusId]) (FK_BusSchedule_Bus)
        /// </summary>
        public virtual Bus Bus { get; set; } // FK_BusSchedule_Bus

        public BusSchedule()
        {
            BusLocation = new System.Collections.Generic.List<BusLocation>();
            StudentBusSchedule = new System.Collections.Generic.List<StudentBusSchedule>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Contact
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.34.1.0")]
    public partial class Contact: BaseEntity, IAuditable, ISoftDelete
    {
        public int ContactId { get; set; } // ContactId (Primary key)
        public string ContactName { get; set; } // ContactName (length: 100)
        public string ContactEmail { get; set; } // ContactEmail (length: 100)
        public string ContactMobileNo { get; set; } // ContactMobileNo (length: 12)
        public string ContactMsg { get; set; } // ContactMsg (length: 500)
        public int CreatedBy { get; set; } // CreatedBy
        public System.DateTime CreatedOn { get; set; } // CreatedOn
        public int UpdatedBy { get; set; } // UpdatedBy
        public System.DateTime UpdatedOn { get; set; } // UpdatedOn
        public bool IsDeleted { get; set; } // IsDeleted

        public Contact()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // MessageBoard
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.34.1.0")]
    public partial class MessageBoard: BaseEntity, IAuditable, ISoftDelete
    {
        public int MessageBoardId { get; set; } // MessageBoardId (Primary key)
        public int ToMsg { get; set; } // ToMsg
        public int FromMsg { get; set; } // FromMsg
        public int MsgStatus { get; set; } // MsgStatus
        public System.DateTime MsgDateTime { get; set; } // MsgDateTime
        public string Msg { get; set; } // Msg (length: 500)
        public int CreatedBy { get; set; } // CreatedBy
        public System.DateTime CreatedOn { get; set; } // CreatedOn
        public int UpdatedBy { get; set; } // UpdatedBy
        public System.DateTime UpdatedOn { get; set; } // UpdatedOn
        public bool IsDeleted { get; set; } // IsDeleted

        // Foreign keys

        /// <summary>
        /// Parent User pointed by [MessageBoard].([FromMsg]) (FK_MessageBoard_User1)
        /// </summary>
        public virtual User User_FromMsg { get; set; } // FK_MessageBoard_User1

        /// <summary>
        /// Parent User pointed by [MessageBoard].([ToMsg]) (FK_MessageBoard_User)
        /// </summary>
        public virtual User User_ToMsg { get; set; } // FK_MessageBoard_User

        public MessageBoard()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Role
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.34.1.0")]
    public partial class Role: BaseEntity, IAuditable, ISoftDelete
    {
        public int RoleId { get; set; } // RoleId (Primary key)
        public string RoleName { get; set; } // RoleName (length: 100)
        public int CreatedBy { get; set; } // CreatedBy
        public System.DateTime CreatedOn { get; set; } // CreatedOn
        public int UpdatedBy { get; set; } // UpdatedBy
        public System.DateTime UpdatedOn { get; set; } // UpdatedOn
        public bool IsDeleted { get; set; } // IsDeleted

        // Reverse navigation

        /// <summary>
        /// Child UserRole where [UserRole].[RoleId] point to this entity (FK_UserRole_Role)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<UserRole> UserRole { get; set; } // UserRole.FK_UserRole_Role

        public Role()
        {
            UserRole = new System.Collections.Generic.List<UserRole>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Room
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.34.1.0")]
    public partial class Room: BaseEntity, IAuditable, ISoftDelete
    {
        public int RoomId { get; set; } // RoomId (Primary key)
        public string RoomName { get; set; } // RoomName (length: 100)
        public int CreatedBy { get; set; } // CreatedBy
        public System.DateTime CreatedOn { get; set; } // CreatedOn
        public int UpdatedBy { get; set; } // UpdatedBy
        public System.DateTime UpdatedOn { get; set; } // UpdatedOn
        public bool IsDeleted { get; set; } // IsDeleted

        // Reverse navigation

        /// <summary>
        /// Child RoomSchedule where [RoomSchedule].[RoomId] point to this entity (FK_RoomSchedule_Room)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<RoomSchedule> RoomSchedule { get; set; } // RoomSchedule.FK_RoomSchedule_Room
        /// <summary>
        /// Child RoomVideo where [RoomVideo].[RoomId] point to this entity (FK_RoomVideo_Room)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<RoomVideo> RoomVideo { get; set; } // RoomVideo.FK_RoomVideo_Room

        public Room()
        {
            RoomSchedule = new System.Collections.Generic.List<RoomSchedule>();
            RoomVideo = new System.Collections.Generic.List<RoomVideo>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // RoomSchedule
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.34.1.0")]
    public partial class RoomSchedule: BaseEntity, IAuditable, ISoftDelete
    {
        public int RoomScheduleId { get; set; } // RoomScheduleId (Primary key)
        public int TeacherId { get; set; } // TeacherId
        public System.DateTime RoomScheduleDate { get; set; } // RoomScheduleDate
        public System.TimeSpan RoomScheduleTime { get; set; } // RoomScheduleTime
        public string RoomScheduleSubject { get; set; } // RoomScheduleSubject (length: 100)
        public int StudentId { get; set; } // StudentId
        public int RoomId { get; set; } // RoomId
        public int CreatedBy { get; set; } // CreatedBy
        public System.DateTime CreatedOn { get; set; } // CreatedOn
        public int UpdatedBy { get; set; } // UpdatedBy
        public System.DateTime UpdatedOn { get; set; } // UpdatedOn
        public bool IsDeleted { get; set; } // IsDeleted

        // Foreign keys

        /// <summary>
        /// Parent Room pointed by [RoomSchedule].([RoomId]) (FK_RoomSchedule_Room)
        /// </summary>
        public virtual Room Room { get; set; } // FK_RoomSchedule_Room

        /// <summary>
        /// Parent Student pointed by [RoomSchedule].([StudentId]) (FK_RoomSchedule_Student)
        /// </summary>
        public virtual Student Student { get; set; } // FK_RoomSchedule_Student

        /// <summary>
        /// Parent User pointed by [RoomSchedule].([TeacherId]) (FK_RoomSchedule_User)
        /// </summary>
        public virtual User User { get; set; } // FK_RoomSchedule_User

        public RoomSchedule()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // RoomVideo
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.34.1.0")]
    public partial class RoomVideo: BaseEntity, IAuditable, ISoftDelete
    {
        public int RoomVideoId { get; set; } // RoomVideoId (Primary key)
        public string RoomVideoUrlId { get; set; } // RoomVideoUrlId (length: 300)
        public string Path { get; set; } // Path (length: 50)
        public int RoomId { get; set; } // RoomId
        public int CreatedBy { get; set; } // CreatedBy
        public System.DateTime CreatedOn { get; set; } // CreatedOn
        public int UpdatedBy { get; set; } // UpdatedBy
        public System.DateTime UpdatedOn { get; set; } // UpdatedOn
        public bool IsDeleted { get; set; } // IsDeleted

        // Foreign keys

        /// <summary>
        /// Parent Room pointed by [RoomVideo].([RoomId]) (FK_RoomVideo_Room)
        /// </summary>
        public virtual Room Room { get; set; } // FK_RoomVideo_Room

        public RoomVideo()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Student
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.34.1.0")]
    public partial class Student: BaseEntity, IAuditable, ISoftDelete
    {
        public int StudentId { get; set; } // StudentId (Primary key)
        public string StudentName { get; set; } // StudentName (length: 100)
        public string StudentImg { get; set; } // StudentImg (length: 200)
        public string StudentAddress { get; set; } // StudentAddress (length: 200)
        public string StudentGender { get; set; } // StudentGender (length: 100)
        public System.DateTime StudentDob { get; set; } // StudentDob
        public string FatherName { get; set; } // FatherName (length: 100)
        public string MotherName { get; set; } // MotherName (length: 100)
        public int ParentId { get; set; } // ParentId
        public string Batch { get; set; } // Batch (length: 100)
        public int CreatedBy { get; set; } // CreatedBy
        public System.DateTime CreatedOn { get; set; } // CreatedOn
        public int UpdatedBy { get; set; } // UpdatedBy
        public System.DateTime UpdatedOn { get; set; } // UpdatedOn
        public bool IsDeleted { get; set; } // IsDeleted

        // Reverse navigation

        /// <summary>
        /// Child RoomSchedule where [RoomSchedule].[StudentId] point to this entity (FK_RoomSchedule_Student)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<RoomSchedule> RoomSchedule { get; set; } // RoomSchedule.FK_RoomSchedule_Student
        /// <summary>
        /// Child StudentBusSchedule where [StudentBusSchedule].[StudentId] point to this entity (FK_StudentBusSchedule_Student)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<StudentBusSchedule> StudentBusSchedule { get; set; } // StudentBusSchedule.FK_StudentBusSchedule_Student
        /// <summary>
        /// Child StudentLocation where [StudentLocation].[StudentId] point to this entity (FK_StudentLocation_Student)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<StudentLocation> StudentLocation { get; set; } // StudentLocation.FK_StudentLocation_Student

        // Foreign keys

        /// <summary>
        /// Parent User pointed by [Student].([ParentId]) (FK_Student_User)
        /// </summary>
        public virtual User User { get; set; } // FK_Student_User

        public Student()
        {
            RoomSchedule = new System.Collections.Generic.List<RoomSchedule>();
            StudentBusSchedule = new System.Collections.Generic.List<StudentBusSchedule>();
            StudentLocation = new System.Collections.Generic.List<StudentLocation>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // StudentBusSchedule
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.34.1.0")]
    public partial class StudentBusSchedule: BaseEntity, IAuditable, ISoftDelete
    {
        public int StudentBusScheduleId { get; set; } // StudentBusScheduleId (Primary key)
        public int BusScheduleId { get; set; } // BusScheduleId
        public int StudentId { get; set; } // StudentId
        public int CreatedBy { get; set; } // CreatedBy
        public System.DateTime CreatedOn { get; set; } // CreatedOn
        public int UpdatedBy { get; set; } // UpdatedBy
        public System.DateTime UpdatedOn { get; set; } // UpdatedOn
        public bool IsDeleted { get; set; } // IsDeleted

        // Foreign keys

        /// <summary>
        /// Parent BusSchedule pointed by [StudentBusSchedule].([BusScheduleId]) (FK_StudentBusSchedule_BusSchedule1)
        /// </summary>
        public virtual BusSchedule BusSchedule { get; set; } // FK_StudentBusSchedule_BusSchedule1

        /// <summary>
        /// Parent Student pointed by [StudentBusSchedule].([StudentId]) (FK_StudentBusSchedule_Student)
        /// </summary>
        public virtual Student Student { get; set; } // FK_StudentBusSchedule_Student

        public StudentBusSchedule()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // StudentLocation
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.34.1.0")]
    public partial class StudentLocation: BaseEntity, IAuditable, ISoftDelete
    {
        public int StudentLocationId { get; set; } // StudentLocationId (Primary key)
        public int StudentId { get; set; } // StudentId
        public System.DateTime LocationTime { get; set; } // LocationTime
        public double Longitute { get; set; } // Longitute
        public double Latitude { get; set; } // Latitude
        public int CreatedBy { get; set; } // CreatedBy
        public System.DateTime CreatedOn { get; set; } // CreatedOn
        public int UpdatedBy { get; set; } // UpdatedBy
        public System.DateTime UpdatedOn { get; set; } // UpdatedOn
        public bool IsDeleted { get; set; } // IsDeleted

        // Foreign keys

        /// <summary>
        /// Parent Student pointed by [StudentLocation].([StudentId]) (FK_StudentLocation_Student)
        /// </summary>
        public virtual Student Student { get; set; } // FK_StudentLocation_Student

        public StudentLocation()
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
        /// Child MessageBoard where [MessageBoard].[FromMsg] point to this entity (FK_MessageBoard_User1)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<MessageBoard> MessageBoard_FromMsg { get; set; } // MessageBoard.FK_MessageBoard_User1
        /// <summary>
        /// Child MessageBoard where [MessageBoard].[ToMsg] point to this entity (FK_MessageBoard_User)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<MessageBoard> MessageBoard_ToMsg { get; set; } // MessageBoard.FK_MessageBoard_User
        /// <summary>
        /// Child RoomSchedule where [RoomSchedule].[TeacherId] point to this entity (FK_RoomSchedule_User)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<RoomSchedule> RoomSchedule { get; set; } // RoomSchedule.FK_RoomSchedule_User
        /// <summary>
        /// Child Student where [Student].[ParentId] point to this entity (FK_Student_User)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Student> Student { get; set; } // Student.FK_Student_User
        /// <summary>
        /// Child UserRole where [UserRole].[UserId] point to this entity (FK_UserRole_User)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<UserRole> UserRole { get; set; } // UserRole.FK_UserRole_User

        public User()
        {
            MessageBoard_FromMsg = new System.Collections.Generic.List<MessageBoard>();
            MessageBoard_ToMsg = new System.Collections.Generic.List<MessageBoard>();
            RoomSchedule = new System.Collections.Generic.List<RoomSchedule>();
            Student = new System.Collections.Generic.List<Student>();
            UserRole = new System.Collections.Generic.List<UserRole>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // UserRole
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.34.1.0")]
    public partial class UserRole: BaseEntity, IAuditable, ISoftDelete
    {
        public int UserRoleId { get; set; } // UserRoleId (Primary key)
        public int UserId { get; set; } // UserId
        public int RoleId { get; set; } // RoleId
        public int CreatedBy { get; set; } // CreatedBy
        public System.DateTime CreatedOn { get; set; } // CreatedOn
        public int UpdatedBy { get; set; } // UpdatedBy
        public System.DateTime UpdatedOn { get; set; } // UpdatedOn
        public bool IsDeleted { get; set; } // IsDeleted

        // Foreign keys

        /// <summary>
        /// Parent Role pointed by [UserRole].([RoleId]) (FK_UserRole_Role)
        /// </summary>
        public virtual Role Role { get; set; } // FK_UserRole_Role

        /// <summary>
        /// Parent User pointed by [UserRole].([UserId]) (FK_UserRole_User)
        /// </summary>
        public virtual User User { get; set; } // FK_UserRole_User

        public UserRole()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }
}

