using Learn_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Learn_Api.Controllers
{
    public class DepartmentController : ApiController
    {
        [HttpGet]
        [Route("api/department/get")]
        public HttpResponseMessage Getname()
        {
            string[] name = { "Theory Of Computation", "Compiler Design", "Data Structure" };
            return Request.CreateResponse(HttpStatusCode.OK,name);
        }
        [HttpGet]
        [Route("api/department/name/{p_name}")]
        public HttpResponseMessage Getdept(string[] p_name)
        {
            
           
            return Request.CreateResponse(HttpStatusCode.OK,p_name);
        }
        [HttpPost]
        [Route("api/department/create")]
        public HttpResponseMessage Add(Department p)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
