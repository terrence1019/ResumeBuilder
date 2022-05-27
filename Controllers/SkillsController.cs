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

            //Session["counter"] = 0;
            //Session["counter"] = GetCounterValue(val);
            Session["counter"] = Globals.j;

            //This allows us to pass the same value of the ApplicantID
            //from the Applicant Model in the ApplicantDetailsPage [View A]
            //to the Personal Model in AddPersonalsPageView [View B]
            ViewBag.TargetID = applicantID;
            ViewBag.Counter = val;

            return View();
        }


        int val { set; get; }

        //This form adds a batch of Skill records to the Skill Table
        [HttpPost]
        public ActionResult AddSkillsFormAction(SkillsViewModel SkillCollection, int applicantID, int counter)
        {

            

            //Count the number of records in the Collection,
            //which is the batch of Skill records
            //var limit = SkillCollection.SkillBatch.Count;
            var limit = counter;
            
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

                //Add ApplicantID to each Skill record
                SkillCollection.SkillBatch[i].ApplicantID = applicantID;

                Console.WriteLine();

                //Add each Skill Record to the Skill Table:
                //skillsTable.Add(SkillCollection.SkillBatch[i]);

                //Save changes to Résumé Database:
                //dbContext.SaveChanges();
            }

            



            Console.WriteLine();
                       

            return RedirectToAction("SkillDetailsSuccess", new { id = applicantID });
        }


        //Add Functions to set SkillEntryID and ApplicantID

        public ActionResult SkillDetailsSuccess(int id)
        {
            
            ViewBag.ApplicantID = id;
            return View();

        }


        [HttpPost]
        public ActionResult GetCounterValue(int SessionCounter)
        {
            val = SessionCounter;
            Globals.j = SessionCounter;
            Session["counter"] = SessionCounter;

            return View(val);
        }

        

    }
}


//https://stackoverflow.com/questions/30401500/update-multiple-records-at-once-in-asp-net-mvc

//https://docs.microsoft.com/en-us/aspnet/core/mvc/views/working-with-forms?view=aspnetcore-6.0

//https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-6.0