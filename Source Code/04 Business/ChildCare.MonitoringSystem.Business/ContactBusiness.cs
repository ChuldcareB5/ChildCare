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
	public class ContactBusiness
	{
		private readonly IRepository<Contact> contactRepository;//Connect user Repository
		private readonly IRepository<User> UserRepository;
		private readonly IUnitOfWork unitOfWork;

		public ContactBusiness(IUnitOfWork unitOfWork)
		{
			this.contactRepository = unitOfWork.GetRepository<IRepository<Contact>>();//Get User From Repository
			this.UserRepository = unitOfWork.GetRepository<IRepository<User>>();//Get User From Repository
			this.unitOfWork = unitOfWork;//Instantiate unitOfWork Variable
		}



		public ContactModel AddContact(ContactModel contactModel)
		{
			var contactEntity = new Contact()
			{
				ContactName = contactModel.ContactName,
				ContactEmail = contactModel.ContactEmail,
				ContactMobileNo = contactModel.ContactMobileNo,
				ContactMsg = contactModel.ContactMsg,
				CreatedBy = -1,
				CreatedOn = DateTime.UtcNow,
				UpdatedBy = -1,
				UpdatedOn = DateTime.UtcNow

			};
			this.contactRepository.Add(contactEntity);
			this.unitOfWork.Save();
			contactModel.ContactId = contactEntity.ContactId;
			return contactModel;
		}

		public ArrayList ViewContactUsDetail()
		{
			var contactEntity = this.contactRepository.GetAll();

			var contact = new List<ContactModel>();
			//var users = new UserModel();
			ArrayList ms = new ArrayList();
			foreach (var cont in contactEntity)
			{
				//var useremail1 = this.contactRepository.GetBy(x => x.UserId == msg.ToMsg).SingleOrDefault();
				//var useremail2 = this.contactRepository.GetBy(x => x.UserId == msg.FromMsg).SingleOrDefault();
				ms.Add(cont.ContactId);
				ms.Add(cont.ContactName);
				ms.Add(cont.ContactEmail);
				ms.Add(cont.ContactMobileNo);
				ms.Add(cont.ContactMsg);

			}
			return ms;
		}

		public ArrayList GetMsgById(int Contactid,int userid)
		{
			var msgEntity = this.contactRepository.GetAll().Where(x => x.ContactId==Contactid).FirstOrDefault();
			var useremail = this.UserRepository.GetBy(x => x.UserId == userid).SingleOrDefault();
			var msgs = new ContactModel();
			ArrayList ms = new ArrayList();
			var toContactemail = this.contactRepository.GetBy(x => x.ContactId == msgEntity.ContactId).SingleOrDefault();
			ms.Add(toContactemail.ContactId);
			ms.Add(msgEntity.ContactEmail);
			ms.Add(useremail.UserEmail);
			this.unitOfWork.Save();

			return ms;
		}



		public ContactModel SendMail(ContactModel contactModel)
		{
			//var tocontactemail = this.contactRepository.GetBy(x => x.ContactEmail == contactdModel.ContactEmail).SingleOrDefault();
			var fromadminemail = "childcaresystemsditb5@gmail.com";
			//var userfrom = this.userRepository.GetBy(x => x.UserId == messageBoardModel.FromMsg).SingleOrDefault();
			//var Toemailid = userto.UserEmail;
			//var Fromemailid = userfrom.UserEmail;
			var toemail = contactModel.ContactEmail;
			MailMessage msg = new MailMessage();

			msg.From = new MailAddress(fromadminemail);
			msg.To.Add(toemail);
			msg.Subject = "Child Care System";
			msg.Body = contactModel.ContactMsg;
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


			//var msgEntity = new ContactModel()
			//{

			//	ContactEmail = toemail;
			//	ToMsg = studentto.ParentId,
			//	FromMsg = messageBoardModel.FromMsg,
			//	MsgStatus = 0,
			//	MsgDateTime = DateTime.UtcNow,
			//	Msg = messageBoardModel.Msg,
			//	CreatedBy = -1,
			//	CreatedOn = DateTime.UtcNow,
			//	UpdatedBy = -1,
			//	UpdatedOn = DateTime.UtcNow
			//};

			//this.msgRepository.Add(msgEntity);
			//this.unitOfWork.Save();
			//messageBoardModel.MessageBoardId = msgEntity.MessageBoardId;

			return contactModel;



		}

	}
}
