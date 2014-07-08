using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CmsMaster.Models
{
    public class CooperatorModel
    {
        public int Id { get; set; }

        [Display(Name="Nazwa")]
        [Required(ErrorMessage="Pole wymagane")]
        [StringLength(100, ErrorMessage = "Maksymalna długość pola to 100 znaków")]
        public string Title { get; set; }

        [Display(Name = "Opis")]
        [StringLength(100, ErrorMessage = "Maksymalna długość pola to 100 znaków")]
        public string Description { get; set; }
        
        [Display(Name="Czy baner?")]
        public bool IsBanner { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [Display(Name = "Adres URL")]
        public string UrlAddress { get; set; }
        
        [Display(Name = "Adres")]
        [StringLength(100, ErrorMessage = "Maksymalna długość pola to 100 znaków")]
        public string Address { get; set; }
        public string FileName { get; set; }

        [Display(Name="Obrazek")]
        public string FilePath { get; set; }
    }
}