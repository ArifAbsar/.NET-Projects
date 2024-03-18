using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.DTO;
using ZeroHunger.EF;

namespace ZeroHunger.Controllers
{
    public class LoginController : Controller
    {
        readonly ZerohungerEntities1 db = new ZerohungerEntities1();
     
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginDTO l) {

            var user =db.Users.FirstOrDefault(u=>u.NAME.Equals(l.NAME) && u.PASS.Equals(l.PASS));
            var resturant=db.Resturants.FirstOrDefault(u=>u.NAME.Equals(l.NAME) && u.TIN_CERTIFICATE.Equals(l.PASS));
            if(user != null && resturant==null) {
                Session["user"] = user;
                if (user.TYPE.Equals("Admin"))
                {
                    Session["admin"] = user;
                    Session["A_name"] = l.NAME;
                    Session["A_ID"] = l.U_ID;
                    return RedirectToAction("Admin","Admin");
                }
                if (user.TYPE.Equals("Employee"))
                {
                    Session["employee"] = l.NAME;
                    return RedirectToAction("Employee", "Employee");
                }
            }
            if(resturant!=null && user==null)
            {
                Session["resturant"] = resturant;
                Session["user"] = l.NAME;
                return RedirectToAction("Resturant", "Resturant");
            }
            else
            {
                return RedirectToAction("Login");
            }
           
        }
    }
}