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
        public ActionResult Login(login p)
        {
            if (ModelState.IsValid)
            {
                var db = new crudContext();
                var user = (from u in db.User 
                            where u.UName == p.Uname && u.Pass == p.Pass
                            select u).FirstOrDefault();

                if (user != null)
                {
                    return RedirectToAction("About");
                }
            }
    
            
             return View(p);
            

            
        }

    }
}