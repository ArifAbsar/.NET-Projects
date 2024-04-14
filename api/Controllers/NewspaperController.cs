using api.EF;
using api.EF.table;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class NewspaperController : ApiController
    {
        readonly NewspaperContext db=new NewspaperContext();
        [HttpGet]
        [Route("api/news/all")]
        public HttpResponseMessage GetallNews()
        {
            var news=db.News.ToList();
            var getnews=Convert(news);
            return Request.CreateResponse(HttpStatusCode.OK,getnews);
        }
        [HttpGet]
        [Route("api/news/Category/{Getcat}")]
        public HttpResponseMessage CategoryWise(int Getcat)
        {
            
            var News = db.News.Where(u => u.CategoryID.Equals(Getcat)).ToList();
            var getNews=Convert(News);
            return Request.CreateResponse(HttpStatusCode.OK,getNews);
        }

        public static NewsDTO Convert(News n)
        {
            return new NewsDTO
            {
                ID = n.ID,
                TITLE = n.TITLE,
                DATE = n.DATE,
                CategoryID=n.CategoryID
            };
        }
        public static News Convert(NewsDTO n)
        {
            return new News
            {
                ID = n.ID,
                TITLE = n.TITLE,
                DATE = n.DATE,
                CategoryID = n.CategoryID
            };
        }
        public static List<NewsDTO> Convert(List<News> data)
        {

            var list = new List<NewsDTO>();
            foreach (var item in data)
            {
                list.Add(Convert(item));

            }
            return list;


        }
    }
}
