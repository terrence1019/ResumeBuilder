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

        [Key] //Primary Key for Personal
        public int PersonalEntryID { get; set; }

        [Required] //This annotation makes database table field NOT NULL
        public virtual int ApplicationId { get; set; }


        //NAME
        [Required] //This annotation makes database table field NOT NULL
        [StringLength(20)] //This annotation defines string length to 20 characters
        [Display(Name = "First Name")] //This annotation provides a clean "alias" for field name
        public string FirstName { get; set; }

        [StringLength(20)]
        [Display(Name = "Middle Name")]
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
        [Display(Name = "Home Number")]
        public string PhoneHome { get; set; }

        [StringLength(14)]
        [Display(Name = "Work Number")]
        public string PhoneWork { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Home Email")]
        public string EmailHome { get; set; }

        [StringLength(30)]
        [Display(Name = "Work Email")]
        public string EmailWork { get; set; }


    }
}