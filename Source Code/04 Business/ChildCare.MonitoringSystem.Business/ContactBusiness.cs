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

		private readonly IUnitOfWork unitOfWork;

		public ContactBusiness(IUnitOfWork unitOfWork)
		{
			this.contactRepository = unitOfWork.GetRepository<IRepository<Contact>>();//Get User From Repository
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

	}
}
