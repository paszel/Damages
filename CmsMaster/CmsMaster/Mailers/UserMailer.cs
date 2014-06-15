using Mvc.Mailer;

namespace CmsMaster.Mailers
{ 
    public class UserMailer : MailerBase, IUserMailer 	
	{
		public UserMailer()
		{
			MasterName="_Layout";
		}
		
		public virtual MvcMailMessage Contact()
		{
			//ViewBag.Data = someObject;
			return Populate(x =>
			{
				x.Subject = "Contact";
				x.ViewName = "Contact";
				x.To.Add("some-email@example.com");
			});
		}
 	}
}