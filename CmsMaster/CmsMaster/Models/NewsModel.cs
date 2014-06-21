using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CmsMaster.Models
{
    public class NewsModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Pole wymagane")]
        [StringLength(100,ErrorMessage="Maksymalna długość pola to 100 znaków")]
        public string Title { get; set; }
        [Required(ErrorMessage="Pole wymagane")]
        public string Content { get; set; }
    }
}