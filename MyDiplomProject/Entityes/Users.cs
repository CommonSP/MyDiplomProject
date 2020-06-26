using System;
using System.Collections.Generic;

namespace MyDiplomProject
{
    public partial class Users
    {
        public Users()
        {
            Children = new List<Children>();
            Messages = new List<Messages>();
            UserInChatRoom = new List<UserInChatRoom>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public int? GroupId { get; set; }
        public string image { get; set; }

        public virtual Groups Group { get; set; }
        public virtual ICollection<Children> Children { get; set; }
        public virtual ICollection<Messages> Messages { get; set; }
        public virtual ICollection<UserInChatRoom> UserInChatRoom { get; set; }
    }
}
