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


        [Route("Personals/AddPersonalsPageView/{applicantID}")]
        public ActionResult AddPersonalsPageView(int applicantID)
        {  

            //This allows us to pass the same value of the ApplicantID
            //from the Applicant Model in the ApplicantDetailsPage [View A]
            //to the Personal Model in AddPersonalsPageView [View B]
            ViewBag.TargetID = applicantID;
            
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

            
            


            return View();

        }


    }
}