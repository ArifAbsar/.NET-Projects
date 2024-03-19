using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.EF;

namespace ZeroHunger.Controllers
{
    public class EmployeeController : Controller
    {
        readonly ZerohungerEntities1 db = new ZerohungerEntities1();
        // GET: Employee
        [HttpGet]
        public ActionResult Employee()
        {
            if (Session["employee"] != null)
            {
                var data = db.Collect_Request.ToList();
                var convertedData = AdminController.Convert(data);
                return View(convertedData);
            }
            return RedirectToAction("Login","Login");
            
        }
        public ActionResult Employee(string name) 
        {
            ViewBag.name = name;
            var empId = db.Users.Where(u => u.NAME.Equals(name, StringComparison.OrdinalIgnoreCase)).Select(u => u.U_ID).FirstOrDefault();
            var data1 = db.Collect_Request.Where(emp => emp.Received_By==empId).Select(p => p.Collectid).FirstOrDefault();
            var data2 = db.Collect_Request.Find(data1);

            if (data2.Status != "Collected")
            {
                data2.Status = "Collected";
                db.SaveChanges();
            }
            else
            {
                TempData["collect"] = "Already Marked as Collected";
                return RedirectToAction("Employee");
            }



    
            return RedirectToAction("Employee");
            
        }
    }

}