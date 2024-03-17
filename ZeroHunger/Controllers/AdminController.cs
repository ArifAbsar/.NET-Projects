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
            var data = db.Collect_Request.ToList();
            var convertedData = Convert(data); 
            var employeeNames = db.Users.Where(u => u.TYPE == "Employee").Select(u => u.U_ID).ToList();
            ViewBag.EmployeeNames = employeeNames;
            Session["emp"] = ViewBag.EmployeeNames;
            return View(convertedData); 
        }
        public ActionResult Assign()
        {
            return View();
        }
        public ActionResult Decline()
        {
            return View();
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