using CmsMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsMaster.ILogic
{
    public interface IUserLogic
    {
        bool IsAuthenticated(string userName, string password);
        void ChangeEmail(string email);
        void ChangePassword(string password);
        UserEmail GetAdminEmail();
        UserPassword GetAdminPassword();
        string GetAdminAvatarPath();
        void SaveAvatarPath(string path);

    }
}
