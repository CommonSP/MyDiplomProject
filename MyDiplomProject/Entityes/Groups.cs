using MyDiplomProject.Entityes;
using System;
using System.Collections.Generic;

namespace MyDiplomProject
{
    public partial class Groups
    {
        public Groups()
        {
            Children = new List<Children>();
            EatMenus = new List<EatMenus>();
            Schedules = new List<Schedules>();
            Users = new List<Users>();
            ImageGroups = new List<ImageGroups>();
        }

        public int GroupId { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }

        public virtual AgeCategory Category { get; set; }
        public virtual ICollection<Children> Children { get; set; }
        public virtual ICollection<EatMenus> EatMenus { get; set; }
        public virtual ICollection<Schedules> Schedules { get; set; }
        public virtual ICollection<Users> Users { get; set; }
        public virtual ICollection<ImageGroups> ImageGroups { get; set; }
    }
}
