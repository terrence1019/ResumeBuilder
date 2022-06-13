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



        //POSTING ACTIONS: POST TO JOB TABLE
        [HttpPost]
        public ActionResult AddJobFormActionQuery
            (int applicantID, string jobNumberID, string companyName, string position, string fromDate, string toDate)
        {





            return View();

        }

        //POSTING ACTIONS: POST TO JOBDETAIL TABLE
        [HttpPost]
        public ActionResult AddJobDetailsFormActionQuery
            (int applicantID, string jobNumberID, string [] jobFunctionsList)
        {


            //PULL UP JOB DETAILS TABLE




            //GET ARRAY ELEMENTS
            var test0 = jobFunctionsList[0];
            Console.WriteLine(test0);

            var test1 = jobFunctionsList[1];
            Console.WriteLine(test1);


            int i = 0;

            int len = jobFunctionsList.Length;

            //ADD EACH JOB FUNCTION TO JOB DETAIL TABLE
            for (i = 0; i < len; i++)
            {
                //Console.WriteLine( jobFunctionsList[i] );
                                

                string JobID = jobNumberID;
                string JobFunctionID = jobNumberID + "_detail_" + i;


                //Create instance of JobDetail Model/Class/Table
                //NOTE: Instance of JobDetail Model/Class/Table = Table Record in JobDetail
                JobDetail jobdetailItem = new JobDetail();

                /* What's going to be required to be saved to the database?
                 * ApplicantID
                 * JobID
                 * JobFunctionID
                 * JobFunction
                */
                jobdetailItem.ApplicantID = applicantID;
                jobdetailItem.JobID = JobID;
                jobdetailItem.JobFunctionID = JobFunctionID;
                jobdetailItem.JobFunction = jobFunctionsList[i];

                //Pull Up JobDetail DB Table:
                var jobdetailsTable = dbContext.jobdetailDB;

                //Add Each Job Detail Item to JobDetail DB Table:
                jobdetailsTable.Add(jobdetailItem);

                //Save Changes to DB Table:
                //dbContext.SaveChanges();

            }




            Console.WriteLine();

            return View();

        }




























    }
}