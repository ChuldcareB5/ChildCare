﻿using ChildCare.MonitoringSystem.Entity;
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

		public UserBusiness(IUnitOfWork unitOfWork)
		{
			this.userRepository = unitOfWork.GetRepository<IRepository<User>>();//Get User From Repository
			this.roleRepository = unitOfWork.GetRepository<IRepository<Role>>();//Get Role From Repository
			this.userroleRepository = unitOfWork.GetRepository<IRepository<UserRole>>();//Get Role From Repository
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
			return this.AddUser(userModel, 2);//Return from method named AddUser where parent id is 2(function call)
		}

		public UserModel AddTeacher(UserModel userModel)
		{
			return this.AddUser(userModel, 1);//Return from method named AddUser where parent id is 2(function call)
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
			var user = this.userRepository.GetBy(x => x.UserName == userModel.UserName && x.UserPassword == userModel.UserPassword).SingleOrDefault();


			var userrole = user != null ? this.userroleRepository.GetBy(x => x.UserId == user.UserId).SingleOrDefault() : null;

			return userrole != null ? userrole.RoleId : 0;


		}
	}
}