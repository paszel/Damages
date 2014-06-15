using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CmsMaster.ILogic;
using CmsMaster.Models;
using CmsMaster.Helpers;

namespace CmsMaster.Logic
{
    public class UserLogic : IUserLogic
    {
        public bool IsAuthenticated(string userName, string password)
        {
            using(var db = new CmsDatabaseEntities())
            {
                var pass =  PasswordHashHelper.Encode(password);
                return db.Authentications.Any(u => u.Username == userName && u.Password == pass);
            }
        }
        public void ChangeEmail(string email)
        {
            using(var db = new CmsDatabaseEntities())
            {
                var user = db.Authentications.First(u => u.Username == "admin");
                user.Email = email;

                db.SaveChanges();
            }
        }

        public void ChangePassword(string password)
        {
            using(var db = new CmsDatabaseEntities())
            {
                var user = db.Authentications.First(u => u.Username == "admin");
                var newPassword = PasswordHashHelper.Encode(password);
                user.Password = newPassword;

                db.SaveChanges();
            }
        }


        private Authentication GetAdmin()
        {
            using(var db = new CmsDatabaseEntities())
            {
                return db.Authentications.First(u => u.Username == "admin");
            }
        }


        public UserEmail GetAdminEmail()
        {
            var admin = GetAdmin();

            return new UserEmail() { Email = admin.Email };
        }


        public UserPassword GetAdminPassword()
        {
            var admin = GetAdmin();
            var password = PasswordHashHelper.Decode(admin.Password);
            return new UserPassword() { OldPassword = password };
        }
    }
}