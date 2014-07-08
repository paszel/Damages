﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CmsMaster.Models
{
    public class NewsModel
    {
        public int Id { get; set; }

        [Display(Name="Tytuł")]
        [Required(ErrorMessage="Pole wymagane")]
        [StringLength(100,ErrorMessage="Maksymalna długość pola to 100 znaków")]
        public string Title { get; set; }
        
        [Display(Name="Zawartość")]
        [Required(ErrorMessage="Pole wymagane")]
        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string Content { get; set; }

        [Display(Name="Data utworzenia")]
        public DateTime Created { get; set; }

    }
}