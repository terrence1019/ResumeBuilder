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
    public class JobDetail
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobDetailEntryID { get; set; }

        [Required]
        public virtual int ApplicantID { get; set; }

        [StringLength(40)]
        [Display(Name = "Job ID")]
        public string JobID { get; set; }

        [StringLength(40)]
        [Display(Name = "Job Function ID")]
        public string JobFunctionID { get; set; }

        [StringLength(200)]
        [Display(Name = "Job Function")]
        public string JobFunction { get; set; }

        



    }
}