using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using MyDiplomProject.Models;

namespace MyDiplomProject.Hubs
{
    
    public class ChatHub : Hub
    {
       private MyDiplomDatabaseContext _db = new MyDiplomDatabaseContext();
       
        public void JoinGroup(string groupName)
        {
             Groups.Add(Context.ConnectionId, groupName);
        }
        public void SendMessage(string message, string groupName,  int userId)
        {
            var groupId = _db.ChatRooms.FirstOrDefault(c => c.NameRoom == groupName).ChatRoomId;
            Messages mes = new Messages { Text = message, Date = DateTime.Now ,UserId=userId,ChatRoomId = groupId };
            _db.Messages.Add(mes);
            _db.SaveChanges();
            var date = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
            Clients.Group(groupName,Context.ConnectionId).Message(message,date);
            
        }
    }
}