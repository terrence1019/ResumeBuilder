using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Required to use Models
using RésuméBuilder.Models;

namespace RésuméBuilder.Controllers
{
    public class PersonalsController : Controller
    {


        //QUERYING A DATABASE
        //[QUERRYING A DATABASE] STEP 01:
        //Need to query the Applicants database table?
        //Place an instance of MyDbContext in Applicants controller
        private MyDbContext dbContext;

        //[QUERRYING A DATABASE] STEP 02:
        //Initialize dbContext via CustomerController class constructor
        public PersonalsController()
        {
            dbContext = new MyDbContext();
        }


        //[QUERRYING A DATABASE] STEP 03:
        //Ensure to properly dispose of instance by overriding the Dispose() method of the Base Controller class
        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }



        //The Page on which the Personals Form will be housed
        [Route("Personals/AddPersonalsPageView/{applicantID}")]
        public ActionResult AddPersonalsPageView(int applicantID)
        {


            //This allows us to pass the same value of the ApplicantID
            //from the Applicant Model in the ApplicantDetailsPage [View A]
            //to the Personal Model in AddPersonalsPageView [View B]
            ViewBag.TargetID = applicantID;


            //Check to see if any pre-existing record exists for applicant with given applicantID
            var personalTable = dbContext.personalDB;



            //var preexistingrecord = personalTable.Find(applicantID);
            var existingRecord =
                personalTable.FirstOrDefault(u => u.ApplicantID == applicantID);


            if(existingRecord != null) return RedirectToAction("PersonalDetailsExist", "Personals", new { id = applicantID });




            return View();
        }



        //ACTION FOUND IN VIEW FOR FORM.
        //USED FOR FORM OPERATIONS IN CONJUNCTION WITH DATABASE (MODEL BINDING)
        [HttpPost]
        public ActionResult AddPersonalsFormAction(Personal personalRecord, int applicantID)
        {

            //Data Entry Checks for ApplicantID ===
            //Value passed from form input field with name="applicantID"
            //Action's parameter name must equal Form's input field name tag 
            //var setID = applicantID;

            //ApplicantID for record is set here as the desired value:
            personalRecord.ApplicantID = applicantID;

            
                       

            //Data Entry Checks Before DB Saves ===
            var appid = personalRecord.ApplicantID;
            var fname = personalRecord.FirstName;
            var lname = personalRecord.LastName;


            //Target Table to Save Record
            var personalTable = dbContext.personalDB;


            //AUTO-INCREMENT EntryID
            int PreExistingRecords = personalTable.Count();
            int AutoIncrementID = ++PreExistingRecords;

            personalRecord.PersonalEntryID = AutoIncrementID;


            //Add Personal Record to Personal Table
            personalTable.Add(personalRecord);

            //Save changes to database
            dbContext.SaveChanges();


            return RedirectToAction("PersonalDetailsSuccess", new { id = applicantID });
            
        }


        public ActionResult PersonalDetailsSuccess(int id)
        {
            ViewBag.ApplicantID = id;
            return View();
        }

        public ViewResult PersonalDetailsExist(int id)
        {
            ViewBag.ApplicantID = id;
            return View();
        }

        public ActionResult PersonalError(int id)
        {
            ViewBag.ApplicantID = id;
            return View();
        }



        //EDIT PERSONAL DETAILS

        //The Page on which the Personals Form will be housed
        [Route("Personals/EditPersonalsPageView/{applicantID}")]
        public ActionResult EditPersonalsPageView(int applicantID)
        {


            //This allows us to pass the same value of the ApplicantID
            //from the Applicant Model in the ApplicantDetailsPage [View A]
            //to the Personal Model in AddPersonalsPageView [View B]
            ViewBag.TargetID = applicantID;


            //THE AIM IS SIMPLE:
            //01: Pull up the Personal DB
            //02: Check to see if any pre-existing record exists for applicant with given applicantID
            //03: Once existing record retrieved, return to record with PageView


            //STEP 01: Pull up the Personal DB
            var personalTable = dbContext.personalDB;



            //STEP 02: Check to see if any pre-existing record exists for applicant with given applicantID
            //Look for Personal Record using ApplicantID
            var existingRecord =
                personalTable.FirstOrDefault(u => u.ApplicantID == applicantID);

            //If Personal Record not found, redirect to appropriate View
            if (existingRecord == null) return RedirectToAction("PersonalDetailsError", "Personals");



            //STEP 03: Once existing record retrieved, return to record with PageView
            return View("EditPersonalsPageView", existingRecord);
        }



        //ACTION FOUND IN VIEW FOR FORM.
        //USED FOR FORM OPERATIONS IN CONJUNCTION WITH DATABASE (MODEL BINDING)
        [HttpPost]
        public ActionResult EditPersonalsFormAction(Personal personalRecord, int applicantID)
        {

            //WHAT WE HAVE TO DO HERE IS UPDATE THE EXISTING RECORD

            //01: Pull up Personal DB
            //02: Get existing record
            //03: Modify existing record data with new values
            //04: Save changes to database


            //STEP 01: Pull up Personal DB
            var personalTable = dbContext.personalDB;


            //STEP 02: Get existing record
            var existingRecord = personalTable.Single(x => x.ApplicantID == applicantID);


            //STEP 03: Modify existing record data with new values
            existingRecord.FirstName = personalRecord.FirstName;
            existingRecord.MiddleName = personalRecord.MiddleName;
            existingRecord.LastName = personalRecord.LastName;
            
            existingRecord.StreetLocation = personalRecord.StreetLocation;
            existingRecord.AreaLocation = personalRecord.AreaLocation;
            existingRecord.RegionLocation = personalRecord.RegionLocation;

            existingRecord.PhoneMobile = personalRecord.PhoneMobile;
            existingRecord.PhoneHome = personalRecord.PhoneHome;
            existingRecord.PhoneWork = personalRecord.PhoneWork;

            existingRecord.EmailHome = personalRecord.EmailHome;
            existingRecord.EmailWork = personalRecord.EmailWork;




            //Save changes to database
            dbContext.SaveChanges();


            return RedirectToAction("PersonalDetailsSuccess", new { id = applicantID });

        }








        //End



    }
}