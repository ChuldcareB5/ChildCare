using ChildCare.MonitoringSystem.Core.Constraints;
using ChildCare.MonitoringSystem.Entity;
using ChildCare.MonitoringSystem.Repository;
using ChildCare.MonitoringSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChildCare.MonitoringSystem.Business
{
    public class UserBusiness
    {
        private readonly IRepository<User> userRepository;
        private readonly IUnitOfWork unitofwork;

        public UserBusiness(IUnitOfWork  unitofwork)
        {
            this.userRepository = unitofwork.GetRepository<IRepository<User>>();
            this.unitofwork = unitofwork;

        }

        public UserModel AddTeacher(UserModel userModel)
        {
            return this.AddUser(userModel, 2);
        }

        private UserModel AddUser(UserModel userModel, int roleid)
        {
            var userEntity = new User()
            {
                UserName = userModel.UserName,
                UserEmail = userModel.UserEmail,
                UserPassword = userModel.UserPassword,
                UserMobileNo = userModel.UserMobileNo,

                CreatedBy = -1,
                CreatedOn = DateTime.UtcNow,
                UpdatedBy = -1,
                UpdatedOn = DateTime.UtcNow
            };
            userEntity.UserRole.Add(new UserRole()
            {
                RoleId = roleid
            });
        this.userRepository.Add(userEntity);
            this.unitofwork.Save();
            userModel.UserId = userEntity.UserId;


            return userModel;
        }
   
    }
}

