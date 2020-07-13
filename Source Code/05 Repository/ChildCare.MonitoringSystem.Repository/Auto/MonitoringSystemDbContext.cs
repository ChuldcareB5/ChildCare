﻿


// ------------------------------------------------------------------------------------------------
// This code was generated by EntityFramework Reverse POCO Generator (http://www.reversepoco.com/).
// Created by Simon Hughes (https://about.me/simon.hughes).
//
// Do not make changes directly to this file - edit the template instead.
//
// The following connection settings were used to generate this file:
//     Connection String:      "Data Source=.;Database=ChildCareSystem;Integrated Security=True;Application Name=EntityFramework Reverse POCO Generator"
// ------------------------------------------------------------------------------------------------
// Database Edition       : Express Edition (64-bit)
// Database Engine Edition: Express

// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable EmptyNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 2.1
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace ChildCare.MonitoringSystem.Repository
{
    using ChildCare.MonitoringSystem.Common;
    using ChildCare.MonitoringSystem.Core.Constraints;
    using ChildCare.MonitoringSystem.Core.Models;
    using ChildCare.MonitoringSystem.Entity;
    using ChildCare.MonitoringSystem.Repository;
    using Microsoft.EntityFrameworkCore;

    #region Unit of work

    public partial interface IMonitoringSystemDbContext : IUnitOfWork, System.IDisposable
    {
        Microsoft.EntityFrameworkCore.DbSet<Bus> Bus { get; set; } // Bus
        Microsoft.EntityFrameworkCore.DbSet<BusLocation> BusLocation { get; set; } // BusLocation
        Microsoft.EntityFrameworkCore.DbSet<BusSchedule> BusSchedule { get; set; } // BusSchedule
        Microsoft.EntityFrameworkCore.DbSet<Contact> Contact { get; set; } // Contact
        Microsoft.EntityFrameworkCore.DbSet<MessageBoard> MessageBoard { get; set; } // MessageBoard
        Microsoft.EntityFrameworkCore.DbSet<Role> Role { get; set; } // Role
        Microsoft.EntityFrameworkCore.DbSet<Room> Room { get; set; } // Room
        Microsoft.EntityFrameworkCore.DbSet<RoomSchedule> RoomSchedule { get; set; } // RoomSchedule
        Microsoft.EntityFrameworkCore.DbSet<RoomVideo> RoomVideo { get; set; } // RoomVideo
        Microsoft.EntityFrameworkCore.DbSet<Student> Student { get; set; } // Student
        Microsoft.EntityFrameworkCore.DbSet<StudentBusSchedule> StudentBusSchedule { get; set; } // StudentBusSchedule
        Microsoft.EntityFrameworkCore.DbSet<StudentLocation> StudentLocation { get; set; } // StudentLocation
        Microsoft.EntityFrameworkCore.DbSet<User> User { get; set; } // User
        Microsoft.EntityFrameworkCore.DbSet<UserRole> UserRole { get; set; } // UserRole

        int SaveChanges();
		System.Threading.Tasks.Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
		Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
		Microsoft.EntityFrameworkCore.DbSet<TEntity> Set<TEntity>() where TEntity : class;
        string ToString();
    }

    #endregion

    #region Database context

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.34.1.0")]
    public partial class MonitoringSystemDbContext : DbContext, IMonitoringSystemDbContext
    {
		public ApplicationContext ApplicationContext { get; private set; }
        public Microsoft.EntityFrameworkCore.DbSet<Bus> Bus { get; set; } // Bus
        public Microsoft.EntityFrameworkCore.DbSet<BusLocation> BusLocation { get; set; } // BusLocation
        public Microsoft.EntityFrameworkCore.DbSet<BusSchedule> BusSchedule { get; set; } // BusSchedule
        public Microsoft.EntityFrameworkCore.DbSet<Contact> Contact { get; set; } // Contact
        public Microsoft.EntityFrameworkCore.DbSet<MessageBoard> MessageBoard { get; set; } // MessageBoard
        public Microsoft.EntityFrameworkCore.DbSet<Role> Role { get; set; } // Role
        public Microsoft.EntityFrameworkCore.DbSet<Room> Room { get; set; } // Room
        public Microsoft.EntityFrameworkCore.DbSet<RoomSchedule> RoomSchedule { get; set; } // RoomSchedule
        public Microsoft.EntityFrameworkCore.DbSet<RoomVideo> RoomVideo { get; set; } // RoomVideo
        public Microsoft.EntityFrameworkCore.DbSet<Student> Student { get; set; } // Student
        public Microsoft.EntityFrameworkCore.DbSet<StudentBusSchedule> StudentBusSchedule { get; set; } // StudentBusSchedule
        public Microsoft.EntityFrameworkCore.DbSet<StudentLocation> StudentLocation { get; set; } // StudentLocation
        public Microsoft.EntityFrameworkCore.DbSet<User> User { get; set; } // User
        public Microsoft.EntityFrameworkCore.DbSet<UserRole> UserRole { get; set; } // UserRole

        public MonitoringSystemDbContext(DbContextOptions<MonitoringSystemDbContext> options, ApplicationContext applicationContext)
            : base(options)
        {
			this.ApplicationContext = applicationContext;
            InitializePartial();
        }

        public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == System.DBNull.Value);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Bus>(entity => 
			{

				entity.ToTable("Bus", "dbo");
				
				entity.Property(x => x.BusId).HasColumnName(@"BusId").IsRequired();

				entity.Property(x => x.BusName).HasColumnName(@"BusName").IsRequired().IsUnicode(false).HasMaxLength(100);

				entity.Property(x => x.BusDriverName).HasColumnName(@"BusDriverName").IsRequired().IsUnicode(false).HasMaxLength(100);

				entity.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").IsRequired();

				entity.Property(x => x.CreatedOn).HasColumnName(@"CreatedOn").IsRequired();

				entity.Property(x => x.UpdatedBy).HasColumnName(@"UpdatedBy").IsRequired();

				entity.Property(x => x.UpdatedOn).HasColumnName(@"UpdatedOn").IsRequired();

				entity.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").IsRequired();

				InitializePartial();
        
			});

			modelBuilder.Entity<BusLocation>(entity => 
			{

				entity.ToTable("BusLocation", "dbo");
				
				entity.HasOne(a => a.Bus).WithMany(b => b.BusLocation).HasForeignKey(c => c.BusId); // FK_BusLocation_Bus
				entity.HasOne(a => a.BusSchedule).WithMany(b => b.BusLocation).HasForeignKey(c => c.BusScheduleId); // FK_BusLocation_BusSchedule
				entity.Property(x => x.BusLocationId).HasColumnName(@"BusLocationId").IsRequired();

				entity.Property(x => x.BusId).HasColumnName(@"BusId").IsRequired();

				entity.Property(x => x.BusScheduleId).HasColumnName(@"BusScheduleId").IsRequired();

				entity.Property(x => x.LocationTime).HasColumnName(@"LocationTime").IsRequired();

				entity.Property(x => x.Longitute).HasColumnName(@"Longitute").IsRequired();

				entity.Property(x => x.Latitude).HasColumnName(@"Latitude").IsRequired();

				entity.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").IsRequired();

				entity.Property(x => x.CreatedOn).HasColumnName(@"CreatedOn").IsRequired();

				entity.Property(x => x.UpdatedBy).HasColumnName(@"UpdatedBy").IsRequired();

				entity.Property(x => x.UpdatedOn).HasColumnName(@"UpdatedOn").IsRequired();

				entity.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").IsRequired();


				InitializePartial();
        
			});

			modelBuilder.Entity<BusSchedule>(entity => 
			{

				entity.ToTable("BusSchedule", "dbo");
				
				entity.HasOne(a => a.Bus).WithMany(b => b.BusSchedule).HasForeignKey(c => c.BusId); // FK_BusSchedule_Bus
				entity.Property(x => x.BusScheduleId).HasColumnName(@"BusScheduleId").IsRequired();

				entity.Property(x => x.BusScheduleDriverName).HasColumnName(@"BusScheduleDriverName").IsRequired().IsUnicode(false).HasMaxLength(100);

				entity.Property(x => x.ToBusSchedule).HasColumnName(@"ToBusSchedule").IsRequired().IsUnicode(false).HasMaxLength(100);

				entity.Property(x => x.FromBusSchedule).HasColumnName(@"FromBusSchedule").IsRequired().IsUnicode(false).HasMaxLength(100);

				entity.Property(x => x.BusScheduleTime).HasColumnName(@"BusScheduleTime").IsRequired();

				entity.Property(x => x.BusScheduleDate).HasColumnName(@"BusScheduleDate").IsRequired();

				entity.Property(x => x.BusId).HasColumnName(@"BusId").IsRequired();

				entity.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").IsRequired();

				entity.Property(x => x.CreatedOn).HasColumnName(@"CreatedOn").IsRequired();

				entity.Property(x => x.UpdatedBy).HasColumnName(@"UpdatedBy").IsRequired();

				entity.Property(x => x.UpdatedOn).HasColumnName(@"UpdatedOn").IsRequired();

				entity.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").IsRequired();


				InitializePartial();
        
			});

			modelBuilder.Entity<Contact>(entity => 
			{

				entity.ToTable("Contact", "dbo");
				
				entity.Property(x => x.ContactId).HasColumnName(@"ContactId").IsRequired();

				entity.Property(x => x.ContactName).HasColumnName(@"ContactName").IsRequired().IsUnicode(false).HasMaxLength(100);

				entity.Property(x => x.ContactEmail).HasColumnName(@"ContactEmail").IsRequired().IsUnicode(false).HasMaxLength(100);

				entity.Property(x => x.ContactMobileNo).HasColumnName(@"ContactMobileNo").IsRequired().IsUnicode(false).HasMaxLength(12);

				entity.Property(x => x.ContactMsg).HasColumnName(@"ContactMsg").IsRequired().IsUnicode(false).HasMaxLength(500);

				entity.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").IsRequired();

				entity.Property(x => x.CreatedOn).HasColumnName(@"CreatedOn").IsRequired();

				entity.Property(x => x.UpdatedBy).HasColumnName(@"UpdatedBy").IsRequired();

				entity.Property(x => x.UpdatedOn).HasColumnName(@"UpdatedOn").IsRequired();

				entity.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").IsRequired();

				InitializePartial();
        
			});

			modelBuilder.Entity<MessageBoard>(entity => 
			{

				entity.ToTable("MessageBoard", "dbo");
				
				entity.HasOne(a => a.User_FromMsg).WithMany(b => b.MessageBoard_FromMsg).HasForeignKey(c => c.FromMsg); // FK_MessageBoard_User1
				entity.HasOne(a => a.User_ToMsg).WithMany(b => b.MessageBoard_ToMsg).HasForeignKey(c => c.ToMsg); // FK_MessageBoard_User
				entity.Property(x => x.MessageBoardId).HasColumnName(@"MessageBoardId").IsRequired();

				entity.Property(x => x.ToMsg).HasColumnName(@"ToMsg").IsRequired();

				entity.Property(x => x.FromMsg).HasColumnName(@"FromMsg").IsRequired();

				entity.Property(x => x.MsgStatus).HasColumnName(@"MsgStatus").IsRequired();

				entity.Property(x => x.MsgDateTime).HasColumnName(@"MsgDateTime").IsRequired();

				entity.Property(x => x.Msg).HasColumnName(@"Msg").IsRequired().IsUnicode(false).HasMaxLength(500);

				entity.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").IsRequired();

				entity.Property(x => x.CreatedOn).HasColumnName(@"CreatedOn").IsRequired();

				entity.Property(x => x.UpdatedBy).HasColumnName(@"UpdatedBy").IsRequired();

				entity.Property(x => x.UpdatedOn).HasColumnName(@"UpdatedOn").IsRequired();

				entity.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").IsRequired();


				InitializePartial();
        
			});

			modelBuilder.Entity<Role>(entity => 
			{

				entity.ToTable("Role", "dbo");
				
				entity.Property(x => x.RoleId).HasColumnName(@"RoleId").IsRequired();

				entity.Property(x => x.RoleName).HasColumnName(@"RoleName").IsRequired().IsUnicode(false).HasMaxLength(100);

				entity.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").IsRequired();

				entity.Property(x => x.CreatedOn).HasColumnName(@"CreatedOn").IsRequired();

				entity.Property(x => x.UpdatedBy).HasColumnName(@"UpdatedBy").IsRequired();

				entity.Property(x => x.UpdatedOn).HasColumnName(@"UpdatedOn").IsRequired();

				entity.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").IsRequired();

				InitializePartial();
        
			});

			modelBuilder.Entity<Room>(entity => 
			{

				entity.ToTable("Room", "dbo");
				
				entity.Property(x => x.RoomId).HasColumnName(@"RoomId").IsRequired();

				entity.Property(x => x.RoomName).HasColumnName(@"RoomName").IsRequired().IsUnicode(false).HasMaxLength(100);

				entity.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").IsRequired();

				entity.Property(x => x.CreatedOn).HasColumnName(@"CreatedOn").IsRequired();

				entity.Property(x => x.UpdatedBy).HasColumnName(@"UpdatedBy").IsRequired();

				entity.Property(x => x.UpdatedOn).HasColumnName(@"UpdatedOn").IsRequired();

				entity.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").IsRequired();

				InitializePartial();
        
			});

			modelBuilder.Entity<RoomSchedule>(entity => 
			{

				entity.ToTable("RoomSchedule", "dbo");
				
				entity.HasOne(a => a.Room).WithMany(b => b.RoomSchedule).HasForeignKey(c => c.RoomId); // FK_RoomSchedule_Room
				entity.HasOne(a => a.Student).WithMany(b => b.RoomSchedule).HasForeignKey(c => c.StudentId); // FK_RoomSchedule_Student
				entity.HasOne(a => a.User).WithMany(b => b.RoomSchedule).HasForeignKey(c => c.TeacherId); // FK_RoomSchedule_User
				entity.Property(x => x.RoomScheduleId).HasColumnName(@"RoomScheduleId").IsRequired();

				entity.Property(x => x.TeacherId).HasColumnName(@"TeacherId").IsRequired();

				entity.Property(x => x.RoomScheduleDate).HasColumnName(@"RoomScheduleDate").IsRequired();

				entity.Property(x => x.RoomScheduleTime).HasColumnName(@"RoomScheduleTime").IsRequired();

				entity.Property(x => x.RoomScheduleSubject).HasColumnName(@"RoomScheduleSubject").IsRequired().IsUnicode(false).HasMaxLength(100);

				entity.Property(x => x.StudentId).HasColumnName(@"StudentId").IsRequired();

				entity.Property(x => x.RoomId).HasColumnName(@"RoomId").IsRequired();

				entity.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").IsRequired();

				entity.Property(x => x.CreatedOn).HasColumnName(@"CreatedOn").IsRequired();

				entity.Property(x => x.UpdatedBy).HasColumnName(@"UpdatedBy").IsRequired();

				entity.Property(x => x.UpdatedOn).HasColumnName(@"UpdatedOn").IsRequired();

				entity.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").IsRequired();


				InitializePartial();
        
			});

			modelBuilder.Entity<RoomVideo>(entity => 
			{

				entity.ToTable("RoomVideo", "dbo");
				
				entity.HasOne(a => a.Room).WithMany(b => b.RoomVideo).HasForeignKey(c => c.RoomId); // FK_RoomVideo_Room
				entity.Property(x => x.RoomVideoId).HasColumnName(@"RoomVideoId").IsRequired();

				entity.Property(x => x.RoomVideoUrlId).HasColumnName(@"RoomVideoUrlId").IsRequired().IsUnicode(false).HasMaxLength(300);

				entity.Property(x => x.Path).HasColumnName(@"Path").IsUnicode(false).HasMaxLength(50);

				entity.Property(x => x.RoomId).HasColumnName(@"RoomId").IsRequired();

				entity.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").IsRequired();

				entity.Property(x => x.CreatedOn).HasColumnName(@"CreatedOn").IsRequired();

				entity.Property(x => x.UpdatedBy).HasColumnName(@"UpdatedBy").IsRequired();

				entity.Property(x => x.UpdatedOn).HasColumnName(@"UpdatedOn").IsRequired();

				entity.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").IsRequired();


				InitializePartial();
        
			});

			modelBuilder.Entity<Student>(entity => 
			{

				entity.ToTable("Student", "dbo");
				
				entity.HasOne(a => a.User).WithMany(b => b.Student).HasForeignKey(c => c.ParentId); // FK_Student_User
				entity.Property(x => x.StudentId).HasColumnName(@"StudentId").IsRequired();

				entity.Property(x => x.StudentName).HasColumnName(@"StudentName").IsRequired().IsUnicode(false).HasMaxLength(100);

				entity.Property(x => x.StudentImg).HasColumnName(@"StudentImg").IsRequired().IsUnicode(false).HasMaxLength(200);

				entity.Property(x => x.StudentAddress).HasColumnName(@"StudentAddress").IsRequired().IsUnicode(false).HasMaxLength(200);

				entity.Property(x => x.StudentGender).HasColumnName(@"StudentGender").IsRequired().IsUnicode(false).HasMaxLength(100);

				entity.Property(x => x.StudentDob).HasColumnName(@"StudentDob").IsRequired();

				entity.Property(x => x.FatherName).HasColumnName(@"FatherName").IsRequired().IsUnicode(false).HasMaxLength(100);

				entity.Property(x => x.MotherName).HasColumnName(@"MotherName").IsRequired().IsUnicode(false).HasMaxLength(100);

				entity.Property(x => x.ParentId).HasColumnName(@"ParentId").IsRequired();

				entity.Property(x => x.Batch).HasColumnName(@"Batch").IsRequired().IsUnicode(false).HasMaxLength(100);

				entity.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").IsRequired();

				entity.Property(x => x.CreatedOn).HasColumnName(@"CreatedOn").IsRequired();

				entity.Property(x => x.UpdatedBy).HasColumnName(@"UpdatedBy").IsRequired();

				entity.Property(x => x.UpdatedOn).HasColumnName(@"UpdatedOn").IsRequired();

				entity.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").IsRequired();


				InitializePartial();
        
			});

			modelBuilder.Entity<StudentBusSchedule>(entity => 
			{

				entity.ToTable("StudentBusSchedule", "dbo");
				
				entity.HasOne(a => a.BusSchedule).WithMany(b => b.StudentBusSchedule).HasForeignKey(c => c.BusScheduleId); // FK_StudentBusSchedule_BusSchedule1
				entity.HasOne(a => a.Student).WithMany(b => b.StudentBusSchedule).HasForeignKey(c => c.StudentId); // FK_StudentBusSchedule_Student
				entity.Property(x => x.StudentBusScheduleId).HasColumnName(@"StudentBusScheduleId").IsRequired();

				entity.Property(x => x.BusScheduleId).HasColumnName(@"BusScheduleId").IsRequired();

				entity.Property(x => x.StudentId).HasColumnName(@"StudentId").IsRequired();

				entity.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").IsRequired();

				entity.Property(x => x.CreatedOn).HasColumnName(@"CreatedOn").IsRequired();

				entity.Property(x => x.UpdatedBy).HasColumnName(@"UpdatedBy").IsRequired();

				entity.Property(x => x.UpdatedOn).HasColumnName(@"UpdatedOn").IsRequired();

				entity.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").IsRequired();


				InitializePartial();
        
			});

			modelBuilder.Entity<StudentLocation>(entity => 
			{

				entity.ToTable("StudentLocation", "dbo");
				
				entity.HasOne(a => a.Student).WithMany(b => b.StudentLocation).HasForeignKey(c => c.StudentId); // FK_StudentLocation_Student
				entity.Property(x => x.StudentLocationId).HasColumnName(@"StudentLocationId").IsRequired();

				entity.Property(x => x.StudentId).HasColumnName(@"StudentId").IsRequired();

				entity.Property(x => x.LocationTime).HasColumnName(@"LocationTime").IsRequired();

				entity.Property(x => x.Longitute).HasColumnName(@"Longitute").IsRequired();

				entity.Property(x => x.Latitude).HasColumnName(@"Latitude").IsRequired();

				entity.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").IsRequired();

				entity.Property(x => x.CreatedOn).HasColumnName(@"CreatedOn").IsRequired();

				entity.Property(x => x.UpdatedBy).HasColumnName(@"UpdatedBy").IsRequired();

				entity.Property(x => x.UpdatedOn).HasColumnName(@"UpdatedOn").IsRequired();

				entity.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").IsRequired();


				InitializePartial();
        
			});

			modelBuilder.Entity<User>(entity => 
			{

				entity.ToTable("User", "dbo");
				
				entity.Property(x => x.UserId).HasColumnName(@"UserId").IsRequired();

				entity.Property(x => x.UserName).HasColumnName(@"UserName").IsRequired().IsUnicode(false).HasMaxLength(100);

				entity.Property(x => x.UserEmail).HasColumnName(@"UserEmail").IsRequired().IsUnicode(false).HasMaxLength(100);

				entity.Property(x => x.UserPassword).HasColumnName(@"UserPassword").IsRequired().IsUnicode(false).HasMaxLength(100);

				entity.Property(x => x.UserMobileNo).HasColumnName(@"UserMobileNo").IsRequired().IsUnicode(false).HasMaxLength(12);

				entity.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").IsRequired();

				entity.Property(x => x.CreatedOn).HasColumnName(@"CreatedOn").IsRequired();

				entity.Property(x => x.UpdatedBy).HasColumnName(@"UpdatedBy").IsRequired();

				entity.Property(x => x.UpdatedOn).HasColumnName(@"UpdatedOn").IsRequired();

				entity.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").IsRequired();

				InitializePartial();
        
			});

			modelBuilder.Entity<UserRole>(entity => 
			{

				entity.ToTable("UserRole", "dbo");
				
				entity.HasOne(a => a.Role).WithMany(b => b.UserRole).HasForeignKey(c => c.RoleId); // FK_UserRole_Role
				entity.HasOne(a => a.User).WithMany(b => b.UserRole).HasForeignKey(c => c.UserId); // FK_UserRole_User
				entity.Property(x => x.UserRoleId).HasColumnName(@"UserRoleId").IsRequired();

				entity.Property(x => x.UserId).HasColumnName(@"UserId").IsRequired();

				entity.Property(x => x.RoleId).HasColumnName(@"RoleId").IsRequired();

				entity.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").IsRequired();

				entity.Property(x => x.CreatedOn).HasColumnName(@"CreatedOn").IsRequired();

				entity.Property(x => x.UpdatedBy).HasColumnName(@"UpdatedBy").IsRequired();

				entity.Property(x => x.UpdatedOn).HasColumnName(@"UpdatedOn").IsRequired();

				entity.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").IsRequired();


				InitializePartial();
        
			});



            OnModelCreatingPartial(modelBuilder);
        }


        partial void InitializePartial();
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
    #endregion

// Generated helper templates
// ChildCare.MonitoringSystem.Entity\Auto\MonitoringSystemDbContext.txt4
// Generated items
// ChildCare.MonitoringSystem.Entity\Auto\Entities.cs
}
// </auto-generated>

