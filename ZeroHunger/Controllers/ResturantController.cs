using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.DTO;
using ZeroHunger.EF;

namespace ZeroHunger.Controllers
{
    public class ResturantController : Controller
    {
        readonly ZerohungerEntities1 db = new ZerohungerEntities1();
        // GET: Resturant
        [HttpGet]
        public ActionResult Resturant()
        {
            if (Session["resturant"] == null)
            {
                return RedirectToAction("Login","Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Resturant(Collect_RequestDTO requestDTO,string restid)
        {
            
            var data = db.Resturants.Where(u => u.NAME.Equals(restid)).Select(p => p.Restid).FirstOrDefault();
                Collect_Request request = new Collect_Request
                {
                    PreserveTime = requestDTO.PreserveTime,
                    Location = requestDTO.Location,
                    Restid = data // Assuming RestaurantId corresponds to the restaurant's ID
                };

                db.Collect_Request.Add(request);
                
                db.SaveChanges();

                return RedirectToAction("Resturant");
            

            // If the model state is not valid, return the same view with errors
            //return View("Resturant");
        }


    }
}