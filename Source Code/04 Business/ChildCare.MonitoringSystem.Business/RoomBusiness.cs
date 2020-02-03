﻿using ChildCare.MonitoringSystem.Core.Constraints;
using ChildCare.MonitoringSystem.Entity;
using ChildCare.MonitoringSystem.Model;
using ChildCare.MonitoringSystem.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChildCare.MonitoringSystem.Business
{
    public class RoomBusiness
    {
        private readonly IRepository<Room> roomRepository;//Connect user Repository
        private readonly IUnitOfWork unitOfWork;

        public RoomBusiness(IUnitOfWork unitOfWork)
        {
            this.roomRepository = unitOfWork.GetRepository<IRepository<Room>>();//Get User From Repository
            this.unitOfWork = unitOfWork;//Instantiate unitOfWork Variable
        }

        public RoomModel AddRoom(RoomModel roomModel)
        {
            var roomEntity = new Room()
            {
                RoomName = roomModel.RoomName,
                CreatedBy = -1,
                CreatedOn = DateTime.UtcNow,
                UpdatedBy = -1,
                UpdatedOn = DateTime.UtcNow
            };

       
            this.roomRepository.Add(roomEntity);
            this.unitOfWork.Save();
            roomModel.RoomId = roomEntity.RoomId;

            return roomModel;
        }

    }
}