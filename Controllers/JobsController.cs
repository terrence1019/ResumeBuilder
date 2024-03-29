﻿using System;
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

        [HttpPost]
        public ActionResult UpdateJobsFormActionQuery
            (string JobID, string company, string position, string fromDate, string toDate)
        {

            //Pull up Job DB
            var jobTable = dbContext.jobDB;


            //Find existing record
            var existingRecord = jobTable.Single(j => j.JobID.Equals(JobID));

            //Modify record data fields for Company and Position
            existingRecord.CompanyName = company;
            existingRecord.Position = position;

            //Convert fromDate and toDate strings to DateTime for database:
            DateTime fDate;
            DateTime tDate;


            //FROM DATE:
            fDate = DateTime.ParseExact(fromDate, "yyyy-MM", null);


            //TO DATE:
            if (toDate.Equals("") || toDate.ToLower().Equals("present"))
            {
                toDate = "9999-12";
                tDate = DateTime.ParseExact(toDate, "yyyy-MM", null);

            }

            else
            {
                tDate = DateTime.ParseExact(toDate, "yyyy-MM", null);
                
            }


            //Modify record data fields for FromDate and ToDate
            existingRecord.FromDate = fDate;
            existingRecord.ToDate = tDate;



            //Save Changes to DB
            dbContext.SaveChanges();

            return View();
        }

        [HttpPost]
        public ActionResult UpdateJobDetailsFormActionQuery
            (string[] jobFunctionIDList, string[] jobFunctionList )
        {

            //jobFunctionIDList - jobFunctionList is a matching pair relating to
            //JobFunctionID - Job matching pair in database

            //Pull up JobDetail DB
            var jobdetailTable = dbContext.jobdetailDB;



            int count = jobFunctionIDList.Length;
            int i;

            var a = jobFunctionIDList[0];
            var b = jobFunctionList[0];


            for (i=0; i<count; i++)
            {

                //Check for JobFunctionID in array against JobFunctionID in database
                string targetRecordID = jobFunctionIDList[i];
                string targetRecordDescription = jobFunctionList[i];

                
                //We need to match JobFunctionID strings using Equals()
                var existingRecord = jobdetailTable.Single(jd => jd.JobFunctionID.Equals(targetRecordID));

                //When record is found, modify description
                existingRecord.JobFunction = jobFunctionList[i];


            }


            //Save Changes to database
            dbContext.SaveChanges();


            return View();
        }

        [HttpPost]
        public ActionResult RemoveJobRecordFormActionQuery
            (string JobID)
        {


            //We have to delete the records with the JobID in the Job DB AND JobDetail DB
            //We use jobid1 to achieve this
            //We send jobid1 to Controller Action called RemoveJobRecordFormActionQuery()
            //Pull up JobDetail DB and Job DB
            //Look for all instances of jobid1 in JobDetail DB and erase
            //Look for instance of jobid1 in Job DB and erase
            //Save Changes


            //DELETE MULTIPLE RECORDS FROM JOBDETAIL TABLE WITH JOBID ==
            var jobdetailTable = dbContext.jobdetailDB;

            //Get all the records with the JobID
            //https://stackoverflow.com/questions/3177113/lambda-expression-for-exists-within-list
            //https://www.tutorialsteacher.com/linq/linq-filtering-operators-where
            //https://stackoverflow.com/questions/853526/using-linq-to-remove-elements-from-a-listt
            var existingJobDetailsRecords = jobdetailTable.Where(jd => jd.JobID == JobID);

            

            //Remove all the records with the JobID
            //https://stackoverflow.com/questions/2519866/how-do-i-delete-multiple-rows-in-entity-framework-without-foreach
            jobdetailTable.RemoveRange(existingJobDetailsRecords);


            //DELETE SINGLE RECORD FROM JOB TABLE WITH JOBID ==
            var jobTable = dbContext.jobDB;

            var existingJobRecord = jobTable.Single(j => j.JobID == JobID);

            jobTable.Remove(existingJobRecord);






            //Save Changes
            dbContext.SaveChanges();

            return View();
        }


        [HttpPost]
        public ActionResult UpdateSingleJobDetail(string JobFunctionID, string JobDescription)
        {
            //Pull up JobDetail DB
            var jobdetailTable = dbContext.jobdetailDB;

            //Look for record using JobFunctionID
            var existingRecord = jobdetailTable.Single(j => j.JobFunctionID == JobFunctionID);

            //Modify current Job Description using new Job Description
            existingRecord.JobFunction = JobDescription;

            //Save Changes to DB
            dbContext.SaveChanges();

            return View();
        }


        [HttpPost]
        public ActionResult RemoveSingleJobDetail(string JobFunctionID)
        {

            //Pull up JobDetail DB
            var jobdetailTable = dbContext.jobdetailDB;

            //Look for record using JobFunctionID
            var existingRecord = jobdetailTable.Single(j => j.JobFunctionID == JobFunctionID);

            //Remove record
            jobdetailTable.Remove(existingRecord);

            //Save Changes to DB
            dbContext.SaveChanges();

            return View();
        }













    }
}