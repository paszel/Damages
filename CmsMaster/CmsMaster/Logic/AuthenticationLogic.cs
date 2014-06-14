using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CmsMaster.ILogic;
using CmsMaster.Models;

namespace CmsMaster.Logic
{
    public class AuthenticationLogic : IAuthenticationLogic
    {
        public bool IsAuthenticated(string userName, string password)
        {
            using(var db = new CmsDatabaseEntities())
            {
                var pass =  Helpers.SHA1.Encode(password);
                return db.Authentications.Any(u => u.Username == userName && u.Password == pass);
            }
        }
    }
}