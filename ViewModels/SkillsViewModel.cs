using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//I need to use one Model: Skills
//I need it for batch adding Skills via Form
using RésuméBuilder.Models;

namespace RésuméBuilder.ViewModels
{
    public class SkillsViewModel
    {

        //A single Skill record (1 row entry)
        //public Skill Skill { get; set; }

        //Multiple Skill records (batch row entries)
        public List<Skill> SkillBatch { get; set; }


    }
}



//https://stackoverflow.com/questions/48157531/save-multiple-rows-simultaneously-from-the-same-form-dotnet-core
//https://www.aspsnippets.com/Articles/Insert-Save-Multiple-rows-records-to-database-using-Entity-Framework-in-ASPNet-MVC.aspx
//https://www.c-sharpcorner.com/UploadFile/4b0136/editing-multiple-records-using-model-binding-in-mvc/
//https://www.aspsnippets.com/questions/122607/Insert-Multiple-records-from-ViewModel-in-ASPNet-MVC/