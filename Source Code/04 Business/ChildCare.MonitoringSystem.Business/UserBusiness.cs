using ChildCare.MonitoringSystem.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using ChildCare.MonitoringSystem.Repository;
using ChildCare.MonitoringSystem.Model;
using System.Linq;
using ChildCare.MonitoringSystem.Core.Constraints;

namespace ChildCare.MonitoringSystem.Business
{
	public class UserBusiness
	{
		private readonly IRepository<User> userRepository;//Connect User Repository
		private readonly IUnitOfWork unitOfWork;
		private readonly IRepository<Role> roleRepository;//Connect Role Repository
		private readonly IRepository<UserRole> userroleRepository;//Connect userRole Repository
        private readonly IRepository<Student> studentRepository;//Connect student Repository

        public UserBusiness(IUnitOfWork unitOfWork)
		{
			this.userRepository = unitOfWork.GetRepository<IRepository<User>>();//Get User From Repository
			this.roleRepository = unitOfWork.GetRepository<IRepository<Role>>();//Get Role From Repository
			this.userroleRepository = unitOfWork.GetRepository<IRepository<UserRole>>();//Get Role From Repository
            this.studentRepository = unitOfWork.GetRepository<IRepository<Student>>();//Get User From Repository

            this.unitOfWork = unitOfWork;//Instantiate unitOfWork Variable
		}

		public UserModel GetUserById(int userId)
		{
			var user = this.userRepository.GetBy(x => x.UserId == userId).SingleOrDefault();

			return user != null ? new UserModel()
			{
                //UserId = user.UserId,
                //UserEmail = user.UserEmail,
                //UserMobileNo = user.UserMobileNo,
                UserName = user.UserName
			}
			: null;
		}

		public UserModel AddParent(UserModel userModel)
		{
			return this.AddUser(userModel, 1);//Return from method named AddUser where parent id is 2(function call)
		}

		public UserModel AddTeacher(UserModel userModel)
		{
			return this.AddUser(userModel, 2);//Return from method named AddUser where parent id is 2(function call)
		}
        
        public StudentModel AddStudent(StudentModel studentModel)
        {
            var studentEntity = new Student()
            {
                StudentName = studentModel.StudentName,
                StudentImg = studentModel.StudentImg,
                StudentAddress = studentModel.StudentAddress,
                StudentGender = studentModel.StudentGender,
                StudentDob = studentModel.StudentDob,
                FatherName = studentModel.FatherName,
                MotherName = studentModel.MotherName,
                ParentId = studentModel.ParentId,
                CreatedBy = -1,
                CreatedOn = DateTime.UtcNow,
                UpdatedBy = -1,
                UpdatedOn = DateTime.UtcNow

            };
            this.studentRepository.Add(studentEntity);
            this.unitOfWork.Save();
           studentModel.StudentId = studentEntity.StudentId;
            return studentModel;
        }

        private UserModel AddUser(UserModel userModel, int roleId)
		{
			var userEntity = new User()
			{
				UserEmail = userModel.UserEmail,
				UserMobileNo = userModel.UserMobileNo,
				UserName = userModel.UserName,
				UserPassword = userModel.UserPassword,
				CreatedBy = -1,
				CreatedOn = DateTime.UtcNow,
				UpdatedBy = -1,
				UpdatedOn = DateTime.UtcNow
			};

			//var roles = this.roleRepository.GetAll();
			//var parentRoleId = roles.First(x => x.RoleName == "Teacher").RoleId;

			userEntity.UserRole.Add(new UserRole()
			{
				RoleId = roleId
			});

			this.userRepository.Add(userEntity);
			this.unitOfWork.Save();
			userModel.UserId = userEntity.UserId;

			return userModel;
		}
        public Int32 UserLogin(UserModel userModel)
        {
            var user = this.userRepository.GetBy(x => x.UserName == userModel.UserName&&x.UserPassword==userModel.UserPassword).SingleOrDefault();
            //var Userid = user.UserId;
           
            var userrole = user!=null?this.userroleRepository.GetBy(x => x.UserId ==user.UserId).SingleOrDefault():null;
            //var roleId = userrole.RoleId;
            var studentId = this.studentRepository.GetBy(x => x.ParentId == user.UserId);
         //   FormsAuthentication.SetAuthCookie(userModel.I, model.RememberMe);
            //return userrole != null ? new UserRoleModel()
            //{
            //    UserId = userrole.UserId,
            //    RoleId=userrole.RoleId
            //}
            //: null;
            return userrole != null ? userrole.RoleId : 0;


        }
    }
}
