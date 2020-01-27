using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ChildCare.MonitoringSystem.Web.Models
{
    public partial class ChildCareSystemContext : DbContext
    {
        public ChildCareSystemContext()
        {
        }

        public ChildCareSystemContext(DbContextOptions<ChildCareSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bus> Bus { get; set; }
        public virtual DbSet<BusSchedule> BusSchedule { get; set; }
        public virtual DbSet<MessageBoard> MessageBoard { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<RoomSchedule> RoomSchedule { get; set; }
        public virtual DbSet<RoomVideo> RoomVideo { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentBusSchedule> StudentBusSchedule { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-VTP9HA9\\SQLEXPRESS;Database=ChildCareSystem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bus>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<BusSchedule>(entity =>
            {
                entity.Property(e => e.BusScheduleDate).HasColumnType("date");

                entity.Property(e => e.BusScheduleDriverName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FromBusSchedule)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ToBusSchedule)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Bus)
                    .WithMany(p => p.BusSchedule)
                    .HasForeignKey(d => d.BusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusSchedule_Bus");
            });

            modelBuilder.Entity<MessageBoard>(entity =>
            {
                entity.HasKey(e => e.MsgId);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Msg)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MsgDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.FromMsgNavigation)
                    .WithMany(p => p.MessageBoardFromMsgNavigation)
                    .HasForeignKey(d => d.FromMsg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MessageBoard_User1");

                entity.HasOne(d => d.ToMsgNavigation)
                    .WithMany(p => p.MessageBoardToMsgNavigation)
                    .HasForeignKey(d => d.ToMsg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MessageBoard_User");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.RoomName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<RoomSchedule>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.RoomScheduleDate).HasColumnType("date");

                entity.Property(e => e.RoomScheduleSubject)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomSchedule)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomSchedule_Room");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.RoomSchedule)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomSchedule_Student");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.RoomSchedule)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomSchedule_User");
            });

            modelBuilder.Entity<RoomVideo>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.RoomVideo1)
                    .IsRequired()
                    .HasColumnName("RoomVideo")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomVideo)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomVideo_Room");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FatherName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MotherName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StudentAddress)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StudentDob).HasColumnType("date");

                entity.Property(e => e.StudentGender)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StudentImg)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_User");
            });

            modelBuilder.Entity<StudentBusSchedule>(entity =>
            {
                entity.Property(e => e.StudentBusScheduleId).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.BusSchedule)
                    .WithMany(p => p.StudentBusSchedule)
                    .HasForeignKey(d => d.BusScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentBusSchedule_BusSchedule1");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentBusSchedule)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentBusSchedule_Student");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserMobileNo)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserRole");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_User");
            });
        }
    }
}
