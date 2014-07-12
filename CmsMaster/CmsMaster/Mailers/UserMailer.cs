using Mvc.Mailer;
using System;

namespace CmsMaster.Mailers
{ 
	public class UserMailer : MailerBase, IUserMailer 	
	{
		public UserMailer()
		{
			MasterName="_Layout";
		}

		private string _toEmail = "test.pawel.klima@gmail.com";
		

		public virtual MvcMailMessage Contact(string name, string password, string reciverEmail)
		{
			ViewBag.Name = name;
			ViewBag.Password = password;

			var reciver = string.IsNullOrEmpty(reciverEmail) ? _toEmail : reciverEmail;

			return Populate(x =>
			{
				x.Subject = "Nowe has³o";
				x.ViewName = "Contact";
				x.To.Add(reciver);
				
			});
		}

		public virtual MvcMailMessage CustomError(Exception exception,string requestUrl, string application="CMSMaster")
		{
			ViewBag.Date = DateTime.Now;
			ViewBag.Application = application;
            ViewBag.RequestUrl = requestUrl;
			ViewBag.Message = exception.StackTrace;

			return Populate(x =>
				{
					x.Subject = string.Format("{0} - B³¹d", application);
					x.ViewName = "Error";
					x.To.Add(_toEmail);
				});
		}

		public MvcMailMessage Contact()
		{
			throw new NotImplementedException();
		}
	}
}