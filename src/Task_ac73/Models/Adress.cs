using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_ac73.Models
{
    public class Adress
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Display(Name = "Town")]
        public string Town { get; set; }
        [Display(Name = "Street")]
        public string Street { get; set; }
        [Display(Name = "Building")]
        public string Building { get; set; }
        [Display(Name = "Postcode")]
        public string Postcode { get; set; }
        [Display(Name = "Date")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Date { get; set; }
    }
}
