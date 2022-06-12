using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Required to use Models and ViewModels
using RésuméBuilder.Models;
using RésuméBuilder.ViewModels;


using System.Data.Entity;

namespace RésuméBuilder.Controllers
{
    public class JobsController : Controller
    {
        //QUERYING A DATABASE
        //[QUERRYING A DATABASE] STEP 01:
        //Need to query the Applicants database table?
        //Place an instance of MyDbContext in Applicants controller
        private MyDbContext dbContext;

        //[QUERRYING A DATABASE] STEP 02:
        //Initialize dbContext via CustomerController class constructor
        public JobsController()
        {
            dbContext = new MyDbContext();
        }

        //[QUERRYING A DATABASE] STEP 03:
        //Ensure to properly dispose of instance by overriding the Dispose() method of the Base Controller class
        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }



        //VIEWS
        //The Page on which the Jobs Form will be housed
        [Route("Jobs/AddJobsPageView/{applicantID}")]
        public ActionResult AddJobsPageView(int applicantID)
        {

            ViewBag.TargetID = applicantID;

            Session["id"] = applicantID;

            return View();
        }































    }
}