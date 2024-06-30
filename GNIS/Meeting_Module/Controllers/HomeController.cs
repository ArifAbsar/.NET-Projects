using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Services;

namespace Meeting_Module.Controllers
{
    
    public class HomeController : Controller
    {
        [HttpGet]
        public JsonResult GetCorporateCustomers()
        {
            var customers = Corporate_Service.GetCorp();
            var customerNames = customers.Select(c => new { c.Id, c.Corporate_Customer_Name }).ToList();
            return Json(customerNames, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetIndividualCustomers()
        {
           var customers = Individual_Service.GetIndi();
            var customerNames = customers.Select(c => new { c.Id, c.Customer_Name }).ToList();
            return Json(customerNames, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetProductServices()
        {
            var productServices = Product_Service.GetProd();
            return Json(productServices, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            return View();
        }


    }
}