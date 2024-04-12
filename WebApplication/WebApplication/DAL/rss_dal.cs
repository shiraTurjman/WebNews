using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication.DAL
{
    public class rss_dal
    {
        private const string RssFeedUrl = "http://news.google.com/news?pz=1&cf=all&ned=en_il&hl=en&output=rss";

        public List<Post> GetTopicsFromRss()
        {

            var cache = HttpContext.Current.Cache;
            var rssFeed = cache["RssFeed"] as List<Post>;

            if (rssFeed == null)
            {
                // fetch the RSS feed
                rssFeed = FetchRssFeed();
                //Store the fetched data in HttpCache with a cache expiration of 10 minutes
                cache.Insert("RssFeed", rssFeed, null, DateTime.Now.AddMinutes(10), TimeSpan.Zero);
            }

            return rssFeed;
        }

        private List<Post> FetchRssFeed()
        {
            var rssItems = new List<Post>();

            try
            {
              //  Load the XML from the RSS feed URL
                var xdoc = XDocument.Load(RssFeedUrl);

                rssItems = (from item in xdoc.Descendants("item")
                            select new Post
                            {
                                Id = Guid.NewGuid().ToString(),
                                Title = item.Element("title")?.Value ?? "",
                                Body = item.Element("description")?.Value ?? "",
                                Link = item.Element("link")?.Value ?? ""
                            }).ToList();
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }

            return rssItems;
        }
    }

    public class Post
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Link { get; set; }
    }
}
