using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDiplomProject.Models
{
    public class Message
    {
        public Users User { get; set; }
        public string groupName { get; set; }
        public int UserId { get; set; }
        public ICollection<Messages> Messages { get; set; }
    }
}