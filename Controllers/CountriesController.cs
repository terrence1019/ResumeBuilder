using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


//Required to use Models
using RésuméBuilder.Models;

using System.Data.Entity;


namespace RésuméBuilder.Controllers
{
    public class CountriesController : Controller
    {


        //QUERYING A DATABASE
        //[QUERRYING A DATABASE] STEP 01:
        //Need to query the Applicants database table?
        //Place an instance of MyDbContext in Applicants controller
        private MyDbContext dbContext;

        //[QUERRYING A DATABASE] STEP 02:
        //Initialize dbContext via CustomerController class constructor
        public CountriesController()
        {
            dbContext = new MyDbContext();
        }

        //[QUERRYING A DATABASE] STEP 03:
        //Ensure to properly dispose of instance by overriding the Dispose() method of the Base Controller class
        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }



        [Route("Countries/CountryPageView")]
        //Page with all countries listed
        public ActionResult CountryPageView()
        {

            return View();

        }


        //Form for Adding Countries to Country Database
        [HttpPost]
        public ActionResult CountryProcessing(string[] countryList)
        {


            //Pull up Country table
            var countryTable = dbContext.countryDB;


            int len = countryList.Length, limit = len - 1, i;


            for (i = 0; i <= limit; i++)
            {



                var countryname = countryList[i];

                //Check to see if Country Exists already:
                var existingCountryName =
                countryTable.FirstOrDefault(u => u.CountryName.Equals(countryname));


                //If it doesn't exist in Country DB, add it
                if(existingCountryName == null)
                {


                    //Create instance of Country Model
                    //Each instance correlates to Country DB Entry
                    Country countryItem = new Country();

                    //Assign each array element to each Model instance
                    countryItem.CountryName = countryname;


                    //Add each country item from list to Country DB
                    countryTable.Add(countryItem);


                    //Save Changes to DB:
                    dbContext.SaveChanges();


                }


                

            }//for





            return View();
        }






    }
}