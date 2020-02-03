using ChildCare.MonitoringSystem.Core.Constraints;
using ChildCare.MonitoringSystem.Entity;
using ChildCare.MonitoringSystem.Model;
using ChildCare.MonitoringSystem.Repository;
using System;
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
        private readonly IRepository<User> userRepository;//Connect user Repository
        private readonly IUnitOfWork unitOfWork;

        public MsgBusiness(IUnitOfWork unitOfWork)
        {
            this.msgRepository = unitOfWork.GetRepository<IRepository<MessageBoard>>();//Get User From Repository
            this.userRepository = unitOfWork.GetRepository<IRepository<User>>();//Get User From Repository
            this.unitOfWork = unitOfWork;//Instantiate unitOfWork Variable
        }


        public Int32 SendMail(MessageBoardModel messageBoardModel)
        {
            var user = this.userRepository.GetBy(x => x.UserId== messageBoardModel.ToMsg).SingleOrDefault();
            var Toemailid = user.UserEmail;
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("childcaresystemsditb5@gmail.com");
            msg.To.Add(Toemailid);
            msg.Subject = "Message to parent";
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

            return 0;
        }
    }
}
