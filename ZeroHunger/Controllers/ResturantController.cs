using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZeroHunger.Controllers
{
    public class ResturantController : Controller
    {
        // GET: Resturant
        [HttpGet]
        public ActionResult Resturant()
        {
            /*if (Session["resturant"] == null)
            {
                return RedirectToAction("Login","Login");
            }*/
            return View();
        }
    }
}