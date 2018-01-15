using MoneyTemplateMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyTemplateMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

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

        [ChildActionOnly]
        public ActionResult List()
        {
            var source = GetMoneyViewModel();
            return View(source);
        }

        private IEnumerable<MoneyViewModel> GetMoneyViewModel()
        {
            HashSet<MoneyViewModel> source = new HashSet<MoneyViewModel>();
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                var item = new MoneyViewModel
                {
                    Amount = random.Next(0, 1500),
                    Category = random.Next(0, 1) == 1 ? "收入" : "支出",
                    CreateTime = new DateTime(2017, 12, random.Next(1, 31))
                };

                source.Add(item);
            }
            return source;
        }
    }
}