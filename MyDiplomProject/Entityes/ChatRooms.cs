using System;
using System.Collections.Generic;

namespace MyDiplomProject
{
    public partial class ChatRooms
    {
        public ChatRooms()
        {
            Messages = new List<Messages>();
            UserInChatRoom = new List<UserInChatRoom>();
        }

        public int ChatRoomId { get; set; }
        public string NameRoom { get; set; }
        public string TypeRoom { get; set; }

        public virtual ICollection<Messages> Messages { get; set; }
        public virtual ICollection<UserInChatRoom> UserInChatRoom { get; set; }
    }
}
