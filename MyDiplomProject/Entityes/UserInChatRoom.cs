using System;
using System.Collections.Generic;

namespace MyDiplomProject
{
    public partial class UserInChatRoom
    {
        public int UserId { get; set; }
        public int ChatRoomId { get; set; }

        public virtual ChatRooms ChatRoom { get; set; }
        public virtual Users User { get; set; }
    }
}
