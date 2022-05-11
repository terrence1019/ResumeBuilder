using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Required for Data Annotations
using System.ComponentModel.DataAnnotations;

using RésuméBuilder.ViewModels;

namespace RésuméBuilder.Models
{
    public class Applicant
    {

        [Required] //This annotation makes database table field NOT NULL
        public int ApplicantID { get; set; }


        //To override certain default conventions and constraints implemented by EF during table creation,
        //we use Data Annotations in square brackets ABOVE the database table field
        //To enable, we have to use the namespace: 
        [Required] //This annotation makes database table field NOT NULL
        [StringLength(77)] //This annotation limits the database table field's varchar length to 77 - varchar(77)
        [Display(Name = "Applicant Username")] //This annotation provides an "alias" for the field variable name
        public string ApplicantUsername { get; set; }
    }
}