using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CmsMaster.Models
{
    public class ContentModel
    {
        public ContentType Type { get; set; }

        [Display(Name="Treść")]
        [Required(ErrorMessage="Pole wymagane")]
        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string ContentDescription { get; set; }
    }
}