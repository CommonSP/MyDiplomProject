using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDiplomProject.Models
{
    public class Home
    {
        public List<EatMenus> EatMenus { get; set; }
        public string Comment { get; set; }
        public List<Schedules> Schedules { get; set;}
        public string groupName { get; set; }


    }
}