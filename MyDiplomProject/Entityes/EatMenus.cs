using System;
using System.Collections.Generic;

namespace MyDiplomProject
{
    public partial class EatMenus
    {
        public int MenuId { get; set; }
        public DateTime Date { get; set; }
        public string Eat { get; set; }
        public string Mod { get; set; }
        public int? GroupId { get; set; }

        public virtual Groups Group { get; set; }
    }
}
