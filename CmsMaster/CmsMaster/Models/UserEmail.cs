using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CmsMaster.Models
{
    public class UserEmail
    {
        [Required(ErrorMessage = "Pole wymagane")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Nie podano prawidłowego adresu email")]
        [StringLength(50, ErrorMessage = "Maksymalna długość pola '{0}' to {1} znaków")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }
    }
}