using System;
using System.Collections.Generic;

namespace MyDiplomProject
{
    public partial class AgeCategory
    {
        public AgeCategory()
        {
            Groups = new HashSet<Groups>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Groups> Groups { get; set; }
    }
}
