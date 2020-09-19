using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParcialLauraAntelo.Models
{
    public class AnteloD
    {
        [Key]
        public string alpha3code { get; set; }

        [Display(Name = "Nombre del pais")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        public string Flag { get; set; }
        [Required]
        public float Area { get; set; }

        [Required]
        public string Region { get; set; }



    }
}