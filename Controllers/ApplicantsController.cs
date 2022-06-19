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
            var username = applicant.ApplicantUsername;


            //Check Applicant DB for to verify if name is not in use
            foreach(var record in applicantTable.ToList())
            {
                //If name is taken, notify user immediately by redirecting to proper page.
                //Match string for string:
                if (record.ApplicantUsername.Equals(username))
                { 
                    return RedirectToAction("UsernameTaken", "Applicants"); 
                }

                //Else...
                else
                {
                    //Add Applicant Record to Applicant Table of DB
                    applicantTable.Add(applicant);

                    //Save Changes to Database / Database Context
                    dbContext.SaveChanges();
                    
                }

            }

            return View("SuccessfullyRegistered");

        }

        //ATTRIBUTE ROUTING
        //Enable attribute routing in RouteConfig.cs for this to work
        [Route("Applicants/ApplicantDetails/{applicantID}")]
        public ActionResult ApplicantDetails (int applicantID)
        {

            //Test Correctness of Data Entry:
            //var val = applicantID;

            var applicantRecord = dbContext.applicantDB.SingleOrDefault(a => a.ApplicantID == applicantID);

            //if (applicantRecord == null) return HttpNotFound();
            if (applicantRecord == null) return RedirectToAction("PersonalDetailsError", "Personals");

            else return View(applicantRecord);
        }

        //RESUME CREATION
        //CreateApplicationPageView()
        //CreateApplicationFormAction(applicantID)
        //ViewApplicantDetails(applicantID)
        //ViewAppicationDetails(applicantID)

        //USING VIEWMODEL
        //ViewModel -> Controller (using ViewModel) -> View
        [Route("Applicants/ResumeVMPageView/{applicantID}")]
        public ActionResult ResumeVM (int applicantID)
        {
            
            //Find the PK in the Applicant Table matching required ApplicantID
            var applicantRecord = dbContext.applicantDB.SingleOrDefault(a => a.ApplicantID == applicantID);
            if (applicantRecord == null) return HttpNotFound();

            //Find the FK in the Personal Table matching required ApplicantID
            var personalRecord = dbContext.personalDB.SingleOrDefault(a => a.ApplicantID == applicantID);
            if (personalRecord == null) return RedirectToAction("PersonalDetailsError","Applicants");


            //Create ViewModel instance to store values from the DB Tables
            var applicantResumeViewModel = new ResumeViewModel();


            //Store Table Records in ViewModel instance created as required:
            applicantResumeViewModel.ApplicantRecordVM = applicantRecord;

            //Check data entry:
            int id = applicantResumeViewModel.ApplicantRecordVM.ApplicantID;
            string name = applicantResumeViewModel.ApplicantRecordVM.ApplicantUsername;


            applicantResumeViewModel.PersonalRecordVM = personalRecord;


            return View(applicantResumeViewModel);

        }

        public ViewResult PersonalDetailsError()
        {
            return View();
        }

        public ViewResult UsernameTaken()
        {
            return View();
        }




    }
}