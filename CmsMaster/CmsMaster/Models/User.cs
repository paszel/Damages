using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CmsMaster.Helpers;

namespace CmsMaster.Models
{
    public class User
    {
        [Required(ErrorMessage = "Pole wymagane")]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj")]
        public bool RememberMe { get; set; }

        //public bool IsValid(string _username, string _password)
        //{
        //    using (var cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Jezus\Documents\GitHub\Damages\CmsMaster\CmsMaster\App_Data\CmsDatabase.mdf;Integrated Security=True"))
        //    {
        //        string _sql = @"SELECT [Username] FROM [dbo].[Authentication] " +
        //               @"WHERE [Username] = @u AND [Password] = @p";
        //        var cmd = new SqlCommand(_sql, cn);
        //        cmd.Parameters
        //            .Add(new SqlParameter("@u", SqlDbType.NVarChar))
        //            .Value = _username;
        //        cmd.Parameters
        //            .Add(new SqlParameter("@p", SqlDbType.NVarChar))
        //            .Value = Helpers.SHA1.Encode(_password);
        //        cn.Open();
        //        var reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            reader.Dispose();
        //            cmd.Dispose();
        //            return true;
        //        }
        //        else
        //        {
        //            reader.Dispose();
        //            cmd.Dispose();
        //            return false;
        //        }
        //    }
        //}
    }
}