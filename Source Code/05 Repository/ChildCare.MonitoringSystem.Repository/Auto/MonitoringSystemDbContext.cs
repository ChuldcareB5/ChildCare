﻿


// ------------------------------------------------------------------------------------------------
// This code was generated by EntityFramework Reverse POCO Generator (http://www.reversepoco.com/).
// Created by Simon Hughes (https://about.me/simon.hughes).
//
// Do not make changes directly to this file - edit the template instead.
//
// The following connection settings were used to generate this file:
//     Connection String:      "Data Source=.;Database=ChildCare;Integrated Security=True;Application Name=EntityFramework Reverse POCO Generator"
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
// TargetFrameworkVersion = 2.2
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
        Microsoft.EntityFrameworkCore.DbSet<Student> Student { get; set; } // Student
        Microsoft.EntityFrameworkCore.DbSet<User> User { get; set; } // User

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
        public Microsoft.EntityFrameworkCore.DbSet<Student> Student { get; set; } // Student
        public Microsoft.EntityFrameworkCore.DbSet<User> User { get; set; } // User

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

			modelBuilder.Entity<Student>(entity => 
			{

				entity.ToTable("Student", "dbo");
				
				entity.HasOne(a => a.User).WithMany(b => b.Student).HasForeignKey(c => c.ParentId); // FK_Student_User
				entity.Property(x => x.StudentId).HasColumnName(@"StudentId").IsRequired();

				entity.Property(x => x.StudentName).HasColumnName(@"StudentName").IsRequired().IsUnicode(false).HasMaxLength(100);

				entity.Property(x => x.StudentImg).HasColumnName(@"StudentImg").IsRequired().HasMaxLength(2147483647);

				entity.Property(x => x.StudentAddress).HasColumnName(@"StudentAddress").IsRequired().IsUnicode(false).HasMaxLength(200);

				entity.Property(x => x.StudentGender).HasColumnName(@"StudentGender").IsRequired().IsUnicode(false).HasMaxLength(100);

				entity.Property(x => x.StudentDob).HasColumnName(@"StudentDob").IsRequired();

				entity.Property(x => x.FatherName).HasColumnName(@"FatherName").IsRequired().IsUnicode(false).HasMaxLength(100);

				entity.Property(x => x.MotherName).HasColumnName(@"MotherName").IsRequired().IsUnicode(false).HasMaxLength(100);

				entity.Property(x => x.ParentId).HasColumnName(@"ParentId").IsRequired();

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



            OnModelCreatingPartial(modelBuilder);
        }


        partial void InitializePartial();
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
    #endregion

// Generated helper templates
// ChildCare.MonitoringSystem\01 Data\ChildCare.MonitoringSystem.Entity\Auto\MonitoringSystemDbContext.txt4
// Generated items
// ChildCare.MonitoringSystem\01 Data\ChildCare.MonitoringSystem.Entity\Auto\Entities.cs
}
// </auto-generated>

