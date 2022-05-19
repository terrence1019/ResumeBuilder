using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RésuméBuilder.Models;
using RésuméBuilder.ViewModels;

namespace RésuméBuilder.ViewModels
{
    public class ResumeViewModel
    {
        //An instance of Applicant Model, i.e., an Applicant Record:
        public Applicant ApplicantRecordVM { get; set; }

        //An instance of Personal Model, i.e., a Personal Record:
        public Personal PersonalRecordVM { get; set; }


        //Used to pull data from Database using a Database Context instance:
        public MyDbContext MyDbContext { get; set; }

    }
}