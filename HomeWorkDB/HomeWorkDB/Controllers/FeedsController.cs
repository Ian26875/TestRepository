using HomeWorkDB.CustomResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;

namespace HomeWorkDB.Controllers
{
    public class FeedsController : Controller
    {


        // GET: Orders
        public ActionResult Index()
        {
            var feed = this.GetFeedData();
            return new RssResult(feed);
        }
        private SyndicationFeed GetFeedData()
        {
            var feed = new SyndicationFeed(
                "北風測試資料",
                "訂單RSS！",
                new Uri(Url.Action("Rss", "Feed", null, "http")));

            var items = new List<SyndicationItem>();




            var item = new SyndicationItem(
               "Name",
                "Adress",
                new Uri(Url.Action("Index", "RegisterAccount", new { area = "Account",id=1 }, "http")),
                "ID",
                DateTime.Now);

            items.Add(item);


            feed.Items = items;
            return feed;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
            base.Dispose(disposing);
        }
    }
}