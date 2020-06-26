using Microsoft.EntityFrameworkCore;
using MyDiplomProject.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyDiplomProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        MyDiplomDatabaseContext db = new MyDiplomDatabaseContext();
        public ActionResult Index()
        {
            
            var user = HttpContext.User.Identity.Name;
            var child = db.Children.Include(c => c.Comments).FirstOrDefault(ch => ch.User.Login == user);
          
            var group = db.Groups.Include(g => g.EatMenus).Include(g => g.Schedules).FirstOrDefault(g => g.GroupId == child.GroupId);
            Home home = new Home() { groupName = group.Name };
            return View(home);
        }
        public ActionResult EditUser(Profil profil)
        {
            var login = HttpContext.User.Identity.Name;
            Users user = db.Users.FirstOrDefault(u => u.Login == login);
            user.FirstName = profil.FirstName;
            user.LastName = profil.LastName;
            user.MiddleName = profil.MiddleName;
            user.Phone = profil.Phone;
            user.Login = profil.EMail;
            db.Update(user);
            db.SaveChanges();
            var ticket = new FormsAuthenticationTicket(2, user.Login, DateTime.Now, DateTime.Now.AddMinutes(60), true,
                            String.Empty);
            var encTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            cookie.Expires = DateTime.Now.AddMinutes(60);
            Response.Cookies.Add(cookie);
            return PartialView(profil);
        }

         public ActionResult GetComment(string dateValue)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime date = DateTime.ParseExact(dateValue, "dd.MM.yyyy", provider);
            var user = HttpContext.User.Identity.Name;
            var child = db.Children.Include(c => c.Comments).FirstOrDefault(ch => ch.User.Login == user);
            try
            {
                var comment = child.Comments.Where(c => c.Date == date.Date).First();
                return PartialView(comment);
            }
            catch
            {
                ViewBag.Comment = "Нет комментариев";
            }
            return PartialView();
        }
        public ActionResult GetSchedules(string dateValue)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime date = DateTime.ParseExact(dateValue, "dd.MM.yyyy", provider);

            var user = HttpContext.User.Identity.Name;
            var child = db.Children.Include(c => c.Comments).FirstOrDefault(ch => ch.User.Login == user);
            var group = db.Groups.Include(g => g.EatMenus).Include(g => g.Schedules).FirstOrDefault(g => g.GroupId == child.GroupId);
            
                List<Schedules> schedules = group.Schedules.Where(s => s.Date == date.Date).ToList();
            if (schedules.Count == 0)
            {
                ViewBag.Schedules = "Нет данных расписания";
                return PartialView();
            }
            else
            {
                return PartialView(schedules);
            }
        }

        public ActionResult GetMenus(string dateValue, string mode)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime date = DateTime.ParseExact(dateValue, "dd.MM.yyyy", provider);
            var user = HttpContext.User.Identity.Name;
            var child = db.Children.Include(c => c.Comments).FirstOrDefault(ch => ch.User.Login == user);
            var group = db.Groups.Include(g => g.EatMenus).Include(g => g.Schedules).FirstOrDefault(g => g.GroupId == child.GroupId);
            ViewBag.Mode = mode;
            
                List<EatMenus> eatMenus = group.EatMenus.Where(e => e.Date == date.Date).ToList();
            if (eatMenus.Count == 0)
            {
                ViewBag.Menus = "Нет данных меню";
                return PartialView();
            }
            else
            {
                return PartialView(eatMenus);
            }  
        }
    }
}