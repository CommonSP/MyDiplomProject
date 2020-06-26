using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDiplomProject.Entityes
{
    public class Comments
    {
        public int CommentId { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public int? ChildId { get; set; }
        public virtual Children Children { get; set; }
    }
}