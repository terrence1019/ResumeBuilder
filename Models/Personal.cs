using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Required for Data Annotations
using System.ComponentModel.DataAnnotations;

namespace RésuméBuilder.Models
{
    public class Personal
    {


        //KEYS
        [Key] //Primary Key for Personal
        public int PersonalEntryID { get; set; }

        //Relates to ApplicantID from Applicant Model
        [Required] //This annotation makes database table field NOT NULL
        public virtual int ApplicantID { get; set; }


        //NAME
        [Required] //This annotation makes database table field NOT NULL
        [StringLength(20)] //This annotation defines string length to 20 characters
        [Display(Name = "First Name")] //This annotation provides a clean "alias" for field name
        public string FirstName { get; set; }

        [StringLength(20)]
        [Display(Name = "Middle Name (Optional)")]
        public string MiddleName { get; set; }
        
        [Required]
        [StringLength(20)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        //ADDRESS
        [Required]
        [StringLength(40)]
        [Display(Name = "Street")]
        public string StreetLocation { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Area")]
        public string AreaLocation { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Region")]
        public string RegionLocation { get; set; }


        //CONTACT
        [Required]
        [StringLength(14)]
        [Display(Name = "Mobile Number")]
        public string PhoneMobile { get; set; }

        [StringLength(14)]
        [Display(Name = "Home Number (Optional)")]
        public string PhoneHome { get; set; }

        [StringLength(14)]
        [Display(Name = "Work Number (If Applicable)")]
        public string PhoneWork { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Home Email (Optional)")]
        public string EmailHome { get; set; }

        [StringLength(30)]
        [Display(Name = "Work Email (If Applicable)")]
        public string EmailWork { get; set; }


    }
}


//http://www.mukeshkumar.net/articles/entityframework/add-a-primary-and-foreign-key-relationship-with-code-first-approach-in-entity-framework