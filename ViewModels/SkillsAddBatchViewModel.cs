using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RésuméBuilder.Models;

namespace RésuméBuilder.ViewModels
{
    public class SkillsAddBatchViewModel
    {

        public IEnumerable<SkillsViewModel> Skill { get; set; }

        public Skill SkillRec { get; set; }
    }
}