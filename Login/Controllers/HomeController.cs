using Login.DataObjects;
using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class HomeController : Controller
    {
        /*public ActionResult Index()
        {
            return View();
        }

       

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }*/
        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View(new login());
        }
        [HttpPost]
        public ActionResult Login(string uname,string pass)
        {
           
            
                if (ValidUser(uname, pass))
                {
                    return RedirectToAction("About");
                }
            
            return View();
        }
        public bool ValidUser(string username, string password)
        {
            var db = new crudContext();
            var user = (from u in db.User
                        where u.UName == username && u.Pass == password
                        select u).FirstOrDefault();

            return user != null;
        }

    }
}