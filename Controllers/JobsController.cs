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




            //PULL UP JOB TABLE
            var jobTable = dbContext.jobDB;


            Job jobItem = new Job();

            //DEALING WITH CONVERTING STRINGS TO DATE-TIME:
            //http://net-informations.com/q/faq/stringdate.html

            //FROM DATE:
            DateTime fDate = DateTime.ParseExact(fromDate, "yyyy-MM", null);

            //TO DATE:
            if ( toDate.Equals("") || toDate.ToLower().Equals("present") )
            {
                toDate = "9999-12";
                DateTime tDate = DateTime.ParseExact(toDate, "yyyy-MM", null);
                jobItem.ToDate = tDate;         
            }

            else
            {
                DateTime tDate = DateTime.ParseExact(toDate, "yyyy-MM", null);
                jobItem.ToDate = tDate;
            }

            jobItem.ApplicantID = applicantID;
            jobItem.JobID = jobNumberID;
            jobItem.CompanyName = companyName;
            jobItem.Position = position;
            jobItem.FromDate = fDate;


            //Add record to Job Database
            jobTable.Add(jobItem);

            //Save Changes to DB:
            dbContext.SaveChanges();

            return View();

        }

        //POSTING ACTIONS: POST TO JOBDETAIL TABLE
        [HttpPost]
        public ActionResult AddJobDetailsFormActionQuery
            (int applicantID, string jobNumberID, string [] jobFunctionsList)
        {

            if (jobFunctionsList != null && jobFunctionsList.Length > 0)
            {

                



                //GET ARRAY ELEMENTS
                //var test0 = jobFunctionsList[0];
                //Console.WriteLine(test0);

                //var test1 = jobFunctionsList[1];
                //Console.WriteLine(test1);




                int len = jobFunctionsList.Length;

                int limit = len - 1;




                //ADD EACH JOB FUNCTION TO JOB DETAIL TABLE

                int i;
                //for (i = 0; i < limit; i++)

                for (i = 0; i <= limit; i++)
                {
                    //Console.WriteLine( jobFunctionsList[i] );

                    //PULL UP JOB DETAILS TABLE
                    var jobdetailTable = dbContext.jobdetailDB;

                    string JobID = jobNumberID;
                    string JobFunctionIDStr = jobNumberID + "_detail_" + i;
                    string JobFunctionID = JobFunctionIDStr.ToString();


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
                    //var jobdetailsTable = dbContext.jobdetailDB;

                    //Add Each Job Detail Item to JobDetail DB Table:
                    jobdetailTable.Add(jobdetailItem);

                    //Save Changes to DB:
                    dbContext.SaveChanges();

                }//for






                /*
                JobDetail jobdetailItem = new JobDetail();

                string JobID = jobNumberID;
                string JobFunctionIDStr = jobNumberID + "_detail_" + 0;
                string JobFunctionID = JobFunctionIDStr.ToString();

                jobdetailItem.ApplicantID = 1;
                jobdetailItem.JobID = JobID;
                jobdetailItem.JobFunctionID = JobFunctionID;
                jobdetailItem.JobFunction = jobFunctionsList[0];

                jobdetailTable.Add(jobdetailItem);


                dbContext.SaveChanges();
                */


            }//Check if array is empty


            Console.WriteLine();

            return View();

        }




        //EDITING JOBS
        public ActionResult EditJobsPageView(int applicantID)
        {

            ViewBag.TargetID = applicantID;

            Session["id"] = applicantID;

            return View();
        }























    }
}