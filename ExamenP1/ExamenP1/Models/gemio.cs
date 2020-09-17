using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenP1.Models
{public enum placetype
    {
        Casa,
        Ventura,
        LasBrisas,
        Burtown,
        Gatsby
    }
    public class gemio
    {
        [Key]
        public int gemioID { get; set; }
        [Required]
        [Display(Name = "Nombre Completo")]
        [StringLength(24,MinimumLength = 2)]
        public string  Friendofgemio { get; set; }
        [Required]
        public placetype Place { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name ="Cumpleaños")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }


    }
}