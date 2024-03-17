using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            //var Counts = data.GroupBy(cr => cr.Received_By).ToDictionary(g => g.Key, g => g.Count());
            //var filteredCollectRequests = data.Where(cr => !Counts.ContainsKey(cr.Received_By) || Counts[cr.Received_By] < 5).ToList();
            var convert = Convert(data);
            //var filteredCollectRequestDTOs = Convert(filteredCollectRequests); // Convert Collect_Request to Collect_RequestDTO
            //var employeeNames = filteredCollectRequestDTOs.Select(cr => cr.Received_By).Distinct().ToList();
            //ViewBag.EmployeeNames = employeeNames;
            var employeeNames = db.Users.Where(u => u.TYPE == "Employee").Select(u => u.NAME).ToList();
            ViewBag.EmployeeNames = employeeNames;
            return View(convert);
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