using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CmsMaster.Models
{
    public class UserPassword
    {
        [Required(ErrorMessage = "Pole wymagane")]
        [DataType(DataType.Password)]
        [Display(Name = "Stare hasło")]
        [StringLength(50, ErrorMessage = "Maksymalna długość pola '{0}' to {1} znaków")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [DataType(DataType.Password)]
        [Display(Name = "Nowe hasło")]
        [StringLength(50, ErrorMessage = "Maksymalna długość pola {0} to {1} znaków, minimum {2} znaków", MinimumLength = 6)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [DataType(DataType.Password)]
        [Display(Name = "Powtórz hasło")]
        [Compare("NewPassword",ErrorMessage="Hasła się nie zgadzają")]
        [StringLength(50, ErrorMessage = "Maksymalna długość pola {0} to {1} znaków, minimum {2} znaków", MinimumLength=6)]
        public string NewPasswordRepeat { get; set; }
    }
}