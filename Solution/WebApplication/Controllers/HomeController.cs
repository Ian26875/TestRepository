using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Services;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private BlogService blogService = new BlogService();

        public ActionResult Index()
        {
            var blogs = blogService.GetAllArticle();
            return View(blogs);
        }

        //public ActionResult Index(int year, int month)
        //{
        //    var blogs = blogService.GetAllArticle(year, month);
        //    return View(blogs);
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}