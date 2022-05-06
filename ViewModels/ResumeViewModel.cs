using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RésuméBuilder.Models;

namespace RésuméBuilder.ViewModels
{
    public class ResumeViewModel
    {
        //An instance of Applicant Model, i.e., an Applicant Record:
        public Applicant ApplicantRecordVM { get; set; }

        //An instance of Personal Model, i.e., a Personal Record:
        public Personal PersonalRecordVM { get; set; }
    }
}