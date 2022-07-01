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
    public class SkillsController : Controller
    {

        //QUERYING A DATABASE
        //[QUERRYING A DATABASE] STEP 01:
        //Need to query the Applicants database table?
        //Place an instance of MyDbContext in Applicants controller
        private MyDbContext dbContext;

        //[QUERRYING A DATABASE] STEP 02:
        //Initialize dbContext via CustomerController class constructor
        public SkillsController()
        {
            dbContext = new MyDbContext();
        }


        //[QUERRYING A DATABASE] STEP 03:
        //Ensure to properly dispose of instance by overriding the Dispose() method of the Base Controller class
        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }



        //The Page on which the Skills Form will be housed
        [Route("Skills/AddSkillsPageView/{applicantID}")]
        public ActionResult AddSkillsPageView(int applicantID)
        {
                        
            //This allows us to pass the same value of the ApplicantID
            //from the Applicant Model in the ApplicantDetailsPage [View A]
            //to the Personal Model in AddPersonalsPageView [View B]
            ViewBag.TargetID = applicantID;

            Session["id"] = applicantID;
                    

            

            return View();

        }





        int val { set; get; }

        Globals currentCount = new Globals();
        





        //This form adds a batch of Skill records to the Skill Table
        [HttpPost]
        public ActionResult AddSkillsFormAction(SkillsViewModel SkillCollection, int applicantID)
        {

            

            //Count the number of records in the Collection,
            //which is the batch of Skill records
            var limit = SkillCollection.SkillBatch.Count;
            
            //Test entries, Sample 1:
            //var a = SkillCollection.SkillBatch[0].SkillCategory;
            //var b = SkillCollection.SkillBatch[0].SkillPoint;
            //Console.WriteLine($"{a} - {b}");

            //Test entries, Sample 2:
            //var c = SkillCollection.SkillBatch[1].SkillCategory;
            //var d = SkillCollection.SkillBatch[1].SkillPoint;
            //Console.WriteLine($"{c} - {d}");


            //Pull up Skills Table from Résumé Database
            var skillsTable = dbContext.skillDB;
                    


            
            //Traverse collection and add each Skill record to skillsTable
            for (int i = 0; i < limit; i++)
            {
                //var x = SkillCollection.SkillBatch[i].SkillCategory;
                //var y = SkillCollection.SkillBatch[i].SkillPoint;

                //Console.WriteLine($"{x} - {y}");


                ////AUTO-MAP FROM SkillsViewModel [ViewModel] to Skill [Model]

                //Add Functions to set SkillEntryID and ApplicantID:
                //Add ApplicantID to each Skill record
                SkillCollection.SkillBatch[i].ApplicantID = applicantID;

                Console.WriteLine();

                //Add each Skill Record to the Skill Table:
                //skillsTable.Add(SkillCollection.SkillBatch[i]);

                //Save changes to Résumé Database:
                //dbContext.SaveChanges();
            }


            //return RedirectToAction("AddSkillsPageView", new { id = applicantID });
            return RedirectToAction("SkillAddedSuccessfully");

        }


        public ActionResult SkillAddedSuccessfully()
        {

            ViewBag.ApplicantID = Session["id"];
            return View();

        }



        public ActionResult SkillDetailsSuccess(int id)
        {
            
            ViewBag.ApplicantID = id;
            return View();

        }

        public PartialViewResult SkillRowCreate()
        {
            
            return PartialView("_SkillRowCreate");

        }


        public PartialViewResult SkillRowCreator()
        {

            return PartialView("_SkillRowCreator");

        }

        public PartialViewResult SkillRowCreator2()
        {

            return PartialView("_SkillRowCreator2");

        }


        public PartialViewResult SkillEntry()
        {

            return PartialView("_SkillEntry");

        }




        [HttpPost]
        public ActionResult AddSkillsFormActionQuery
            (string skillCategory, string skillPoint, int applicantID)
        {


            //INSERT RECORD INTO DATABASE
            Skill skillItem = new Skill();

            skillItem.SkillCategory = skillCategory;
            skillItem.SkillPoint = skillPoint;
            skillItem.ApplicantID = applicantID;

            //Pull up Skills Table from Résumé Database
            var skillsTable = dbContext.skillDB;


            skillsTable.Add(skillItem);
            dbContext.SaveChanges();


            Console.WriteLine();

            return View();

        }


        //[Route("Skills/EditSkillsPageView/{applicantID}")]
        public ActionResult EditSkillsPageView(int applicantID)
        {
            ViewBag.TargetID = applicantID;

            Session["id"] = applicantID;

            return View();
        }









        [HttpPost]
        public ActionResult CollectSkills (IEnumerable<SkillsViewModel> skillbatch, int applicantID)
        {

            Console.WriteLine();

            return RedirectToAction("SkillDetailsSuccess", new { id = applicantID });

        }



    }
}


//https://stackoverflow.com/questions/30401500/update-multiple-records-at-once-in-asp-net-mvc

//https://docs.microsoft.com/en-us/aspnet/core/mvc/views/working-with-forms?view=aspnetcore-6.0

//https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-6.0