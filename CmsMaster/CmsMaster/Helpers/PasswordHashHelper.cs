using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CmsMaster.Helpers
{
    public class PasswordHashHelper
    {
        public static string Encode(string password)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(password);
            return System.Convert.ToBase64String(plainTextBytes);
        }


        public static string Decode(string password)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(password);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}