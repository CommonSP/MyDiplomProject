using MyDiplomProject.Entityes;
using System;
using System.Collections.Generic;

namespace MyDiplomProject
{
    public partial class Children
    {
        public Children()
        {
            Comments = new List<Comments>();
        }
        public int ChildId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime Burn { get; set; }
        public string Description { get; set; }
        public int? GroupId { get; set; }
        public int? UserId { get; set; }

        public virtual Groups Group { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
    }
}
