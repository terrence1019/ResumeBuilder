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

            ViewBag.TargetID = applicantID;
            
            return View();
        }



        //ACTION FOUND IN VIEW FOR FORM.
        //USED FOR FORM OPERATIONS IN CONJUNCTION WITH DATABASE (MODEL BINDING)
        [HttpPost]
        public ActionResult AddPersonalsFormAction(Personal personalRecord)
        {

            var personalTable = dbContext.personalDB;

            var name = personalRecord.FirstName;
            


            return View();

        }


    }
}