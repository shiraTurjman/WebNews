using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.DAL;

namespace WebApplication
{
    public partial class News1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTopics();
            }
        }
        protected void BindTopics()
        {
            var rssFetcher = new rss_dal();
            rptTopics.DataSource = rssFetcher.GetTopicsFromRss();
            rptTopics.DataBind();
        }
    }

}