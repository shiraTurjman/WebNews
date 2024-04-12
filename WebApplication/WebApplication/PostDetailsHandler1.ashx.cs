using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApplication.DAL;

namespace WebApplication
{
    /// <summary>
    /// Summary description for PostDetailsHandler1
    /// </summary>
    public class PostDetailsHandler1 : IHttpHandler
    {
        [HttpGet]
        public void ProcessRequest(HttpContext context)
        {
            
            string postId = context.Request.QueryString["postId"];
            Console.WriteLine(postId);
            var rssFetcher = new rss_dal();
            var post = rssFetcher.GetTopicsFromRss().Find(p => p.Id == postId);

            if (post != null)
            {
                
                context.Response.ContentType = "application/json";
                context.Response.Write($"{{\"Title\":\"{post.Title}\",\"Body\":\"{post.Body}\",\"Link\":\"{post.Link}\"}}");
                
            }
        }

        
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}