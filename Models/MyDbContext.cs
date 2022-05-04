//REQUIRED FOR EF (ENTITY FRAMEWORK) MIGRATIONS
/*
 * This class had to be created FIRST in order to use the "enable-migrations" command in Nuget Package Manager Console
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//This namespace facilitates Data Migrations
using System.Data.Entity;


/*
 * A DbContext instance represents a combination of the Unit Of Work and Repository patterns
 * such that it can be used to query from a database
 * and group together changes that will then be written back to the store as a unit.
 * DbContext is conceptually similar to ObjectContext.
 */


//Then type in Nuget Package Manager Console:
// Enable-Migrations -ProjectName <YOUR_PROJECT_NAME> -ContextTypeName <YOUR_CONTEXT_NAME>
// In this case:
// Enable-Migrations -ProjectName Vidly -ContextTypeName MyDbContext



namespace RésuméBuilder.Models
{
    public class MyDbContext : DbContext
    {

        public MyDbContext()
        {
        }

        //For Applicant Model:
        public DbSet <Applicant> applicantDB { get; set; }

    }
}