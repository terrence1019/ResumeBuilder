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
    public class Job
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobEntryID { get; set; }

        [Required]
        public virtual int ApplicantID { get; set; }

        [StringLength(35)]
        [Display(Name = "Job ID")]
        public string JobID { get; set; }
        
        [StringLength(60)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        //https://www.c-sharpcorner.com/UploadFile/4b0136/perform-data-annotation-in-Asp-Net-mvc-5/
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM}", ApplyFormatInEditMode = true)]
        [Display(Name = "From Date")]
        public DateTime FromDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM}", ApplyFormatInEditMode = true)]
        [Display(Name = "To Date")]
        public DateTime ToDate { get; set; }



    }
}