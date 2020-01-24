using ChildCare.MonitoringSystem.Core.Constraints;
using ChildCare.MonitoringSystem.Entity;
using ChildCare.MonitoringSystem.Model;
using ChildCare.MonitoringSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChildCare.MonitoringSystem.Business
{
    public class UserBusiness
    {
        private readonly IRepository<User> userRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Role> roleRepository;

        public UserBusiness(IUnitOfWork unitOfWork)
        {
            this.userRepository = unitOfWork.GetRepository<IRepository<User>>();
            this.roleRepository = unitOfWork.GetRepository<IRepository<Role>>();
            this.unitOfWork = unitOfWork;
        }

        public UserModel AddParent(UserModel userModel)
        {
            return this.AddUser(userModel, 2);
        }

        public UserModel AddTeacher(UserModel userModel)
        {
            return this.AddUser(userModel, 1);
        }

        private UserModel AddUser(UserModel userModel,int roleId)
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


    }

}
