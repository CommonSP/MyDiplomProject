using Microsoft.EntityFrameworkCore;
using MyDiplomProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDiplomProject.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        MyDiplomDatabaseContext db = new MyDiplomDatabaseContext();
        // GET: Message
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult AddGroup()
        {
            List<Users> usersInGroup =new List<Users>();
            List<UserInChatRoom> userInChatRooms = new List<UserInChatRoom>();
            var login = HttpContext.User.Identity.Name;
            var user = db.Users
                .Include(u => u.UserInChatRoom)
                    .ThenInclude(uc => uc.ChatRoom)
                        .ThenInclude(cr => cr.UserInChatRoom)
                            .ThenInclude(m => m.User)
                            .FirstOrDefault(u => u.Login == login);
            var groups = user.UserInChatRoom.Select(u => u.ChatRoom).Where(cr=>cr.TypeRoom=="1").ToList();
            foreach(ChatRooms items in groups)
            {
                foreach(UserInChatRoom item in items.UserInChatRoom )
                    if(item.User!=user)
                    usersInGroup.Add(item.User);
            }
            var users = db.Users.ToList();
            foreach(Users item in usersInGroup)
            {
                users.Remove(item);
            }
            users.Remove(user);
            return PartialView(users);
        }
        public ActionResult Messages()
        {
            var user = db.Users
                .Include(u=>u.UserInChatRoom)
                    .ThenInclude(uc=>uc.ChatRoom)
                        .ThenInclude(cr=>cr.UserInChatRoom)
                            .ThenInclude(m => m.User)
                .Include(u=>u.UserInChatRoom)
                    .ThenInclude(uc=>uc.ChatRoom)
                        .ThenInclude(cr=>cr.Messages)
                        .ThenInclude(m=>m.User)
                .FirstOrDefault(u => u.Login == HttpContext.User.Identity.Name);
            var groups = user.UserInChatRoom.Select(uc => uc.ChatRoom).ToList();
            
            return PartialView(groups);
        }
        public ActionResult MessagesUser(string groupName)
        {
            var room = db.ChatRooms
                .Include(u=>u.UserInChatRoom)
                    .ThenInclude(uc=>uc.User)
                .FirstOrDefault(g => g.NameRoom == groupName);

            var users = room.UserInChatRoom.Select(u => u.User).ToList();
            var user = db.Users.FirstOrDefault(u => u.Login == HttpContext.User.Identity.Name);
            users.Remove(user);

            var chatroom = db.ChatRooms
                .Include(g => g.Messages)
                    .ThenInclude(m=>m.User)
                .FirstOrDefault(g => g.NameRoom == groupName);

            Message message = new Message();
            message.Messages = chatroom.Messages;
            message.User = users.First();
            message.groupName = chatroom.NameRoom;
            message.UserId = user.UserId;
           
            return PartialView(message);
        }
        public ActionResult AddUserInGroup(int id)
        {
            Users mainUser = db.Users.FirstOrDefault(u => u.Login == HttpContext.User.Identity.Name); 
            Users user = db.Users.Find(id);
            ChatRooms chatRoom = new ChatRooms { NameRoom = user.Login + HttpContext.User.Identity.Name };
            db.ChatRooms.Add(chatRoom);
            db.SaveChanges();
            mainUser.UserInChatRoom.Add(new UserInChatRoom { ChatRoomId = chatRoom.ChatRoomId, UserId = mainUser.UserId });
            user.UserInChatRoom.Add(new UserInChatRoom { ChatRoomId = chatRoom.ChatRoomId, UserId = user.UserId });
            db.SaveChanges();
            
            return RedirectToAction("MessagesUser", new {groupName = chatRoom.NameRoom });
        }
        public ActionResult MessagesLeft(string groupName)
        {
            var user = db.Users
                .Include(u => u.UserInChatRoom)
                    .ThenInclude(uc => uc.ChatRoom)
                        .ThenInclude(cr => cr.UserInChatRoom)
                            .ThenInclude(m => m.User)
                .Include(u => u.UserInChatRoom)
                    .ThenInclude(uc => uc.ChatRoom)
                        .ThenInclude(cr => cr.Messages)
                        .ThenInclude(m => m.User)
                .FirstOrDefault(u => u.Login == HttpContext.User.Identity.Name);
            var groups = user.UserInChatRoom.Select(uc => uc.ChatRoom).Where(cr=>cr.NameRoom!=groupName).ToList();
            return PartialView(groups);
        }
    }
}