using ChildCare.MonitoringSystem.Core.Constraints;
using ChildCare.MonitoringSystem.Entity;
using ChildCare.MonitoringSystem.Model;
using ChildCare.MonitoringSystem.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ChildCare.MonitoringSystem.Business
{
	public class MsgBusiness
	{
		private readonly IRepository<MessageBoard> msgRepository;//Connect user Repository
		private readonly IRepository<Student> studentRepository;//Connect user Repository

		private readonly IRepository<User> userRepository;//Connect user Repository
		private readonly IUnitOfWork unitOfWork;

		public MsgBusiness(IUnitOfWork unitOfWork)
		{
			this.msgRepository = unitOfWork.GetRepository<IRepository<MessageBoard>>();//Get User From Repository
			this.userRepository = unitOfWork.GetRepository<IRepository<User>>();//Get User From Repository
			this.studentRepository = unitOfWork.GetRepository<IRepository<Student>>();//Get User From Repository
			this.unitOfWork = unitOfWork;//Instantiate unitOfWork Variable
		}


		public MessageBoardModel SendMail(MessageBoardModel messageBoardModel)
		{
			var studentto = this.studentRepository.GetBy(x => x.StudentId == messageBoardModel.ToMsg).SingleOrDefault();
			var userto = this.userRepository.GetBy(x => x.UserId == studentto.ParentId).SingleOrDefault();
			var userfrom = this.userRepository.GetBy(x => x.UserId == messageBoardModel.FromMsg).SingleOrDefault();
			var Toemailid = userto.UserEmail;
			var Fromemailid = userfrom.UserEmail;
			MailMessage msg = new MailMessage();

			msg.From = new MailAddress(Fromemailid);
			msg.To.Add(Toemailid);
			msg.Subject = "Child Care System";
			msg.Body = messageBoardModel.Msg;
			//msg.Priority = MailPriority.High;

			using (SmtpClient client = new SmtpClient())
			{
				client.EnableSsl = true;
				client.UseDefaultCredentials = false;
				client.Credentials = new NetworkCredential("childcaresystemsditb5@gmail.com", "childcaresystemsditb5123@");
				client.Host = "smtp.gmail.com";
				client.Port = 587;
				client.DeliveryMethod = SmtpDeliveryMethod.Network;

				client.Send(msg);
			}
			var msgEntity = new MessageBoard()
			{
				ToMsg = studentto.ParentId,
				FromMsg = messageBoardModel.FromMsg,
				MsgStatus = 0,
				MsgDateTime = DateTime.UtcNow,
				Msg = messageBoardModel.Msg,
				CreatedBy = -1,
				CreatedOn = DateTime.UtcNow,
				UpdatedBy = -1,
				UpdatedOn = DateTime.UtcNow
			};
			this.msgRepository.Add(msgEntity);
			this.unitOfWork.Save();
			messageBoardModel.MessageBoardId = msgEntity.MessageBoardId;

			return messageBoardModel;
		}



		public MessageBoardModel SendParentMail(MessageBoardModel messageBoardModel)
		{
			var studentfrom = this.studentRepository.GetBy(x => x.StudentId == messageBoardModel.FromMsg).SingleOrDefault();
			var userfrom = this.userRepository.GetBy(x => x.UserId == studentfrom.ParentId).SingleOrDefault();
			var userto = this.userRepository.GetBy(x => x.UserId == messageBoardModel.ToMsg).SingleOrDefault();

			var Fromemailid = userfrom.UserEmail;

			var pass = userfrom.UserPassword;
			var Toemailid = userto.UserEmail;
			MailMessage msg = new MailMessage();

			msg.From = new MailAddress(Fromemailid);
			msg.To.Add(Toemailid);
			msg.Subject = "Child Care System";
			msg.Body = messageBoardModel.Msg;
			//msg.Priority = MailPriority.High;

			using (SmtpClient client = new SmtpClient())
			{
				client.EnableSsl = true;
				client.UseDefaultCredentials = false;
				client.Credentials = new NetworkCredential(Fromemailid, pass);
				client.Host = "smtp.gmail.com";
				client.Port = 587;
				client.DeliveryMethod = SmtpDeliveryMethod.Network;

				client.Send(msg);
			}


			var msgEntity = new MessageBoard()
			{
				FromMsg = studentfrom.ParentId,
				ToMsg = messageBoardModel.ToMsg,
				MsgStatus = 0,
				MsgDateTime = DateTime.UtcNow,
				Msg = messageBoardModel.Msg,
				CreatedBy = -1,
				CreatedOn = DateTime.UtcNow,
				UpdatedBy = -1,
				UpdatedOn = DateTime.UtcNow
			};

			this.msgRepository.Add(msgEntity);
			this.unitOfWork.Save();
			messageBoardModel.MessageBoardId = msgEntity.MessageBoardId;

			return messageBoardModel;
		}

		public ArrayList ViewedMsgDetail(int id)
		{
			var msgEntity = this.msgRepository.GetAll().Where(x=>x.ToMsg==id && x.MsgStatus==1);

			var msgs = new List<MessageBoardModel>();
			var users = new UserModel();
			ArrayList ms = new ArrayList();
			foreach (var msg in msgEntity)
			{
				var useremail1 = this.userRepository.GetBy(x => x.UserId == msg.ToMsg).SingleOrDefault();
				var useremail2 = this.userRepository.GetBy(x => x.UserId == msg.FromMsg).SingleOrDefault();
				ms.Add(useremail1.UserEmail);
				ms.Add(useremail2.UserEmail);
				ms.Add(msg.Msg);
				//ms.Add(msg.MessageBoardId);
			
				ms.Add(msg.MsgDateTime);


                    //msgs.Add(new MessageBoardModel()
                    //{
                    //	MessageBoardId = msg.MessageBoardId,
                    //	ToMsg = useremail.UserEmail,
                    //	FromMsg = msg.FromMsg,
                    //	Msg = msg.Msg,
                    //	MsgDateTime = msg.MsgDateTime,

                    //});
                
            }
			return ms;
		}


        public ArrayList NewMsgDetail(int id)
        {
            var msgEntity = this.msgRepository.GetAll().Where(x => x.ToMsg == id && x.MsgStatus == 0);

            var msgs = new List<MessageBoardModel>();
            var users = new UserModel();
            ArrayList ms = new ArrayList();
            foreach (var msg in msgEntity)
            {
                    var useremail1 = this.userRepository.GetBy(x => x.UserId == msg.ToMsg).SingleOrDefault();
                    var useremail2 = this.userRepository.GetBy(x => x.UserId == msg.FromMsg).SingleOrDefault();
                    ms.Add(useremail1.UserEmail);
                    ms.Add(useremail2.UserEmail);
                    ms.Add(msg.Msg);
                    ms.Add(msg.MessageBoardId);
                    ms.Add(msg.MsgDateTime);
            }
            return ms;
        }

        public int GetMsgCount(int id)
        {
            var msgCount = this.msgRepository.GetAll().Where(x=>x.MsgStatus==0 && x.ToMsg==id).Count();
            return msgCount;
        }


        public List<UserModel> GetMsgUser(int id)
        {

            var msgList = this.msgRepository.GetAll().Where(x => x.MsgStatus == 0 && x.ToMsg == id);

            var users = new List<UserModel>();

            foreach (var user in msgList)
            {
                var touser = this.userRepository.GetAll().Where(y => y.UserId == user.FromMsg).FirstOrDefault();
                users.Add(new UserModel()
                {
                    UserEmail = touser.UserEmail
                });
            }

            return users;
        }

        //public MessageBoard GetMsgById(int id)
        //{
        //    var msg = this.msgRepository.GetAll().Where(x => x.MessageBoardId == id).FirstOrDefault();
        //    msg.MsgStatus = 1;
        //    this.unitOfWork.Save();
        //    return msg;
        //}


        public ArrayList GetMsgById(int id)
        {
            var msgEntity = this.msgRepository.GetAll().Where(x => x.MessageBoardId == id).FirstOrDefault();

            var msgs = new MessageBoardModel();
            var users = new UserModel();
            ArrayList ms = new ArrayList();
                var toUseremail = this.userRepository.GetBy(x => x.UserId == msgEntity.ToMsg).SingleOrDefault();
                var fromUseremail = this.userRepository.GetBy(x => x.UserId == msgEntity.FromMsg).SingleOrDefault();
                ms.Add(toUseremail.UserEmail);
                ms.Add(fromUseremail.UserEmail);
                ms.Add(msgEntity.Msg);

                ms.Add(msgEntity.MsgDateTime);

            msgEntity.MsgStatus = 1;
            this.unitOfWork.Save();

            return ms;
        }





    }
}
