using System;
using System.Collections.Generic;

namespace MyDiplomProject
{
    public partial class Messages
    {
        public int MessageId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int ChatRoomId { get; set; }
        public int UserId { get; set; }

        public virtual ChatRooms ChatRoom { get; set; }
        public virtual Users User { get; set; }
    }
}
