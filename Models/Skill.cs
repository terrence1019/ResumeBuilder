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
    public class Skill
    {   
        //Primary Key that Auto-Increments:
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillEntryID { get; set; }

        [Required]
        public virtual int ApplicantID { get; set; }

        [StringLength(35)]
        [Display(Name = "Skill Category")]
        public string SkillCategory { get; set; }

        [Required]
        [StringLength(35)]
        [Display(Name = "Skill Point")]
        public string SkillPoint { get; set; }
    }
}


//Auto-Incrementing
//https://stackoverflow.com/questions/60663277/databasegenerateddatabasegeneratedoption-identity-vs-key