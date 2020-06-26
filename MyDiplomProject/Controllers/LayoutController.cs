using MyDiplomProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDiplomProject.Controllers
{
    [Authorize]
    public class LayoutController : Controller
    {
        MyDiplomDatabaseContext db = new MyDiplomDatabaseContext();
        // GET: Layout
        public ActionResult UserData()
        {
            var user = HttpContext.User.Identity.Name;
            Users users = db.Users.FirstOrDefault(u => u.Login == user);
            Profil userProfil = new Profil();
            userProfil.FirstName = users.FirstName;
            userProfil.LastName = users.LastName;
            userProfil.MiddleName = users.MiddleName;
            userProfil.EMail = users.Login;
            userProfil.Phone = users.Phone;
            userProfil.image = users.image;
            return PartialView(userProfil);
        }
        public ActionResult UserProfil()
        {
            var user = HttpContext.User.Identity.Name;
            Users users = db.Users.FirstOrDefault(u => u.Login == user);
            Profil userProfil = new Profil();
            userProfil.FirstName = users.FirstName;
            userProfil.LastName = users.LastName;
            userProfil.MiddleName = users.MiddleName;
            userProfil.EMail = users.Login;
            userProfil.Phone = users.Phone;
            userProfil.image = users.image;
            return PartialView(userProfil);
        }
    }
}