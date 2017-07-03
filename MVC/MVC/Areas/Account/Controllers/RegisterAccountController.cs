using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Areas.Account.Controllers
{
    public class RegisterAccountController : Controller
    {
        // GET: Account/RegisterAccount
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AccountLists()
        {
            return PartialView();
        }
    }
}