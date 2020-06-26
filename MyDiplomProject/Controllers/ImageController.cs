using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDiplomProject.Controllers
{
    [Authorize]
    public class ImageController : Controller
    {
        MyDiplomDatabaseContext db = new MyDiplomDatabaseContext();
        public void Upload(HttpPostedFileBase upload)
        {
            if (upload != null)
            {  
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                System.IO.Directory.CreateDirectory(Server.MapPath("~/UsersImage/") + HttpContext.User.Identity.Name);
                upload.SaveAs(Server.MapPath("~/UsersImage/"+ HttpContext.User.Identity.Name+"/" + fileName));
                var user = db.Users.FirstOrDefault(u => u.Login == HttpContext.User.Identity.Name);
                user.image = Convert.ToString("/UsersImage/"+ HttpContext.User.Identity.Name+"/" + fileName);
                db.Update(user);
                db.SaveChanges();
            }
        }
        public ViewResult Index()
        {
            return View();
        }
    }
}