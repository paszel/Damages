using Mvc.Mailer;

namespace CmsMaster.Mailers
{ 
    public interface IUserMailer
    {
            
			MvcMailMessage Contact();
	}
}