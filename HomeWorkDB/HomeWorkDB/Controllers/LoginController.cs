using HomeWorkDB.Models.Service;
using HomeWorkDB.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HomeWorkDB.Controllers
{
    public class LoginController : Controller
    {
        protected LoginService service;

        public LoginController()
        {
            service = new LoginService();
        }

        [AllowAnonymous]
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
                ModelState.AddModelError("Account", "查無資料");
                return View(viewModel);
            }
            // 登入時清空所有 Session 資料
            Session.RemoveAll();

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
              viewModel.Account,//你想要存放在 User.Identy.Name 的值，通常是使用者帳號
              DateTime.Now,
              DateTime.Now.AddMinutes(30),
              false,//將管理者登入的 Cookie 設定成 Session Cookie
             "",//userdata看你想存放啥
              FormsAuthentication.FormsCookiePath);

            string encTicket = FormsAuthentication.Encrypt(ticket);

            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

            return View("Login");
        }
        [Authorize]
        public ActionResult Login()
        {
            return View();
        }
    }
}