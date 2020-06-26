using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyDiplomProject.Controllers;
using MyDiplomProject.Models;
using Nest;

namespace MyDiplomProject.Tests
{
  
    [TestClass]
    public class HomeControllerTest
     
    {
        
        [TestMethod]
        public void Index()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.About() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Contact() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
    [TestClass]
    public class AccountControllerTest
    {
        public MyDiplomDatabaseContext db = new MyDiplomDatabaseContext();
        [TestMethod]
        public void Index()
        {
            
            AccountController controller = new AccountController(db);
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

    }

   

    [TestClass]
    public class AuthorizationTest
    {
        
        [TestMethod]
        public void Index()
        {

            string expected = "Index";
           
            Login login = new Login() { Name = "Evgeniy2000sa@yandex.ru", Password = "mn124560MN" };
            AccountController controller = new AccountController(db );
          
            RedirectToRouteResult result = controller.Index(login) as RedirectToRouteResult;

           
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }
       
    }

}
