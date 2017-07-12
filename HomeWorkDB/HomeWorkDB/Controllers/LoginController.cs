using HomeWorkDB.Models.Service;
using HomeWorkDB.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWorkDB.Controllers
{
    public class LoginController : Controller
    {
        protected LoginService service;

        public LoginController()
        {
            service = new LoginService();
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var result=service.CheckUserInform(viewModel.Account, viewModel.Password);
            if (!result)
            {
                return View(viewModel);
            }
            else
            {

            }
            return View();
        }
    }
}