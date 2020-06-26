using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using MyDiplomProject.Models;

namespace MyDiplomProject.Controllers
{
    public class AccountController : Controller
    {
        MyDiplomDatabaseContext _db = new MyDiplomDatabaseContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(Login model)
        {
            if (ModelState.IsValid)
            {
                Users user = _db.Users.FirstOrDefault(u => u.Login == model.Name);
                if (user != null)
                {
                    if (user.Password == model.Password)
                    {
                        var ticket = new FormsAuthenticationTicket(2, model.Name, DateTime.Now, DateTime.Now.AddMinutes(60), true,
                            String.Empty);
                        var encTicket = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                        cookie.Expires = DateTime.Now.AddMinutes(60);
                        Response.Cookies.Add(cookie);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Message = "Неправильно введен логин и/или пароль";
                    }

                }
                else
                {
                    ViewBag.Message = "Такого пользователя не существует";
                }
            }

            return View(model);
        }

      
    }
}