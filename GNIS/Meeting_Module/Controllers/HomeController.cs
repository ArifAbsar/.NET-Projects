using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.DTO;
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
           var indcustomers = Individual_Service.GetIndi();
            var indcustomerNames = indcustomers.Select(c => new {c.Customer_Name }).ToList();
            return Json(indcustomerNames, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetProductServices()
        {
            var productServices = Product_Service.GetProd();
            var productNames = productServices.Select(p => new { p.id, p.Prod_Name, p.unit }).ToList();
            return Json(productNames, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SaveMeetingMinutes(Meeting_Minutes_MasterDTO meetingData)
        {
            try
            {

                Meetings_Minutes_Details_Services dbhelper = new Meetings_Minutes_Details_Services();
                dbhelper.SaveMeetingMinutesMaster(meetingData);
                foreach (var productService in meetingData.ProductsServices)
                {
                    dbhelper.SaveMeetingMinutesDetails(productService.ProductServiceId, productService.Quantity, productService.Unit);
                }
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                // Log the exception and return an error message
                return Json(new { success = false, message = ex.Message });
            }
        }
        public ActionResult Index()
        {
            return View();
        }


    }
}