using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//I need to use two Models: Applicant and Personal
using RésuméBuilder.Models;

namespace RésuméBuilder.ViewModels
{
    public class AddPersonalsViewModel
    {

        //An instance of Applicant Model:
        public Applicant ApplicantRec { get; set; }

        //An instance of Personal Model:
        public Personal PersonalRec { get; set; }

    }
}