using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Required for Data Annotations
using System.ComponentModel.DataAnnotations;

//Required for Database Schema Structure
using System.ComponentModel.DataAnnotations.Schema;

namespace RésuméBuilder.Models
{
    public class Country
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryID { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Country")]
        public string CountryName { get; set; }

    }
}