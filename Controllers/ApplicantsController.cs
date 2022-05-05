using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Required to use Models
using RésuméBuilder.Models;




namespace RésuméBuilder.Controllers
{
    public class ApplicantsController : Controller
    {
        

        //QUERYING A DATABASE
        //[QUERRYING A DATABASE] STEP 01:
        //Need to query the Applicants database table?
        //Place an instance of MyDbContext in Applicants controller
        private MyDbContext dbContext;


        //[QUERRYING A DATABASE] STEP 02:
        //Initialize dbContext via CustomerController class constructor
        public ApplicantsController()
        {
            dbContext = new MyDbContext();
        }


        //[QUERRYING A DATABASE] STEP 03:
        //Ensure to properly dispose of instance by overriding the Dispose() method of the Base Controller class
        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }




        //BASIC LIST OF USERS IN DATABASE
        //ListOfApplicantsPageView()
        public ActionResult ListOfApplicantsPageView()
        {
            var applicantTable = dbContext.applicantDB;

            //Counts the number of records in Applicant Table to determine if empty
            if (applicantTable.Count() == 0)
                return View("NoApplicants");


            return View(applicantTable);
        }


        //REGISTERING A USER FOR RESUME SERVICE
        //RegisterUserPageView()
        [Route("Applicants/RegisterUserPageView")]
        public ViewResult RegisterUserPageView()
        {
            return View();
        }


        //RegisterUserFormAction()
        //ACTION FOUND IN VIEW FOR FORM.
        //USED FOR FORM OPERATIONS IN CONJUNCTION WITH DATABASE (MODEL BINDING)
        [HttpPost]
        public ActionResult RegisterUserFormAction(Applicant applicant)
        {
            var applicantTable = dbContext.applicantDB;


            //AUTO-INCREMENT ApplicantID
            //Count the number of pre-existing records
            //Casting to byte required due to DataType of ApplicantID
            int PreExistingRecords = applicantTable.Count();
            int AutoIncrementID = ++PreExistingRecords;

            //Auto-Increment ApplicantID by 1 for the new member
            applicant.ApplicantID = AutoIncrementID;

            //Test Correctness of Data Entry:
            //var name = applicant.ApplicantUsername;

            //Add Applicant Record to Applicant Table of DB
            applicantTable.Add(applicant);

            //Save Changes to Database / Database Context
            dbContext.SaveChanges();

            return View("SuccessfullyRegistered");
        }

        //ATTRIBUTE ROUTING
        //Enable attribute routing in RouteConfig.cs
        //https://stackoverflow.com/questions/18052813/the-parameters-dictionary-contains-a-null-entry-for-parameter-id-of-non-nullab
        [Route("Applicants/ApplicantDetails/{applicantID}")]
        public ActionResult ApplicantDetails (int applicantID)
        {

            //Test Correctness of Data Entry:
            //var val = applicantID;

            var applicantRecord = dbContext.applicantDB.SingleOrDefault(a => a.ApplicantID == applicantID);

            if (applicantRecord == null) return HttpNotFound();

            return View(applicantRecord);
        }

        //RESUME CREATION
        //CreateApplicationPageView()
        //CreateApplicationFormAction(applicantID)
        //ViewApplicantDetails(applicantID)
        //ViewAppicationDetails(applicantID)



    }
}