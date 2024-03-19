using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.DTO;
using ZeroHunger.EF;

namespace ZeroHunger.Controllers
{
    public class AdminController : Controller
    {
        readonly ZerohungerEntities1 db = new ZerohungerEntities1();
        [HttpGet]
        public ActionResult Admin()
        {
            if (Session["admin"] != null)
            {
                var data = db.Collect_Request.ToList();
                var convertedData = Convert(data);

                return View(convertedData);
            }
            return RedirectToAction("Login", "Login");
        }
       
        [HttpGet]
        public ActionResult Assign(int collectID)
        {
            ViewBag.CollectId = collectID; 
            var user = db.Users.Where(u => u.TYPE == "Employee").ToList();
            var convertUser = Convert(user);
            return View(convertUser);
        }
        [HttpPost]
        public ActionResult Assign(int collectID,int emp_id,string name)
        {
            ViewBag.name = name;
            var adminId = db.Users.Where(u => u.NAME.Equals(name, StringComparison.OrdinalIgnoreCase)).Select(u => u.U_ID).FirstOrDefault();
            //var ad = admin.Select;
            var collect = db.Collect_Request.Find(collectID);
            if (collect != null && collect.Status!="Approved")
            {
                collect.Approved_by = adminId;
                collect.Received_By = emp_id;
                collect.Status = "Approved";
                collect.CollectDate = DateTime.Now;
                db.SaveChanges();
                
            }
            else if (collect.Status == "Approved")
            {
                TempData["Error"] = "Already Approved";
                return RedirectToAction("Admin");
            }
            return RedirectToAction("Admin");
        }
        public ActionResult Decline(int collectID)
        {
            var collect = db.Collect_Request.Find(collectID);
            if (collect != null && collect.Status != "Rejected")
            {
                collect.Status = "Rejected";
                db.SaveChanges();
            }
            else if (collect.Status == "Rejected")
            {
                TempData["decline"] = "Already Rejected";
                return RedirectToAction("Admin");
            }
            return RedirectToAction("Admin");
        }

        public static UserDTO Convert(User user)
        {
            return new UserDTO
            {
                NAME = user.NAME,
                U_ID = user.U_ID,
                TYPE = user.TYPE,
            };
        }
        public static User Convert(UserDTO c)
        {
            return new User
            {
                NAME = c.NAME,
                U_ID = c.U_ID,
                TYPE = c.TYPE,
                

            };
        }
        public static List<UserDTO> Convert(List<User> data)
        {

            var list = new List<UserDTO>();
            foreach (var item in data)
            {
                list.Add(Convert(item));

            }
            return list;


        }

        public static Collect_RequestDTO Convert(Collect_Request c)
        {
            return new Collect_RequestDTO
            {
                Collectid=c.Collectid,
                Restid = c.Restid,
                PreserveTime=c.PreserveTime,
                Location = c.Location,
                Status = c.Status,
                CollectDate = c.CollectDate
            };
        }
        public static Collect_Request Convert(Collect_RequestDTO c)
        {
            return new Collect_Request
            {
                Collectid = c.Collectid,
                Restid=c.Restid,
                PreserveTime=c.PreserveTime,
                Location = c.Location,
                Status = c.Status,
                CollectDate = c.CollectDate

            };
        }

        public static List<Collect_RequestDTO> Convert(List<Collect_Request> data) {
        
            var list = new List<Collect_RequestDTO>();
            foreach (var item in data)
            {
                list.Add(Convert(item));

            }
            return list;
        
        
        }

    }
}