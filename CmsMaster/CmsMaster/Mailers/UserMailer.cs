using Mvc.Mailer;

namespace CmsMaster.Mailers
{ 
	public class UserMailer : MailerBase, IUserMailer 	
	{
		public UserMailer()
		{
			MasterName="_Layout";
		}

		private string _toEmail = "jezus805@gmail.com";
		public string ToEmail { set { _toEmail = value; } }

        private string _password;
        public string Password { set { _password = value; } }

        private string _name;
        public string Name { set { _name = value; } }

		public virtual MvcMailMessage Contact()
		{
            ViewBag.Name = _name;
			ViewBag.Password = _password;
			return Populate(x =>
			{
				x.Subject = "Nowe has³o";
				x.ViewName = "Contact";
				x.To.Add(_toEmail);
				
			});
		}
	}
}