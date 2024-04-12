using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.DAL;

namespace WebApplication.Controllers
{
    public class NewsController : Controller
    {
        private readonly rss_dal _rssFeedService;

        public NewsController()
        {
            _rssFeedService = new rss_dal();
        }
        //function to get post details by postId
        [HttpGet]
        public ActionResult GetPostDetails(string postId)
        {
            //get post by post id
            var post = _rssFeedService.GetTopicsFromRss().Find(p => p.Id == postId);

            if (post != null)
            {
                //convert to json 
                return Json(JsonConvert.SerializeObject(post),JsonRequestBehavior.AllowGet);
            }
            else
            {
                Console.WriteLine("err");
                return null;
            }
        }
    }
}