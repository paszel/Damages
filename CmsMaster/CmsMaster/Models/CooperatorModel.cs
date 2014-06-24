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
        
        public bool IsBanner { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [Display(Name = "Adres URL")]
        public string UrlAddress { get; set; }
        
        [Display(Name = "Adres")]
        [StringLength(100, ErrorMessage = "Maksymalna długość pola to 100 znaków")]
        public string Address { get; set; }

        [StringLength(15, ErrorMessage = "Maksymalna długość pola to 100 znaków")]
        [Display(Name = "Numer tel.")]
        public string PhoneNumber { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}