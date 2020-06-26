using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDiplomProject.Entityes
{
    public partial class ImageGroups
    {
        public int ImageId { get; set; }
        public string Image { get; set; }
        public int? GroupId { get; set; }
        public virtual Groups Groups { get; set; }
    }
}