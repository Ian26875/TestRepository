using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication.Services;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class MemberController : Controller
    {
        private MemberService memberService = new MemberService();
        private MailService mailService = new MailService();
        [AllowAnonymous]
        public ActionResult Login()
        {
            //判斷使用者是否已經登入驗證
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(MemberLoginViewModel loginMember)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            string msg = "";
            string userName = loginMember.UserName;
            string password = loginMember.Password;
            bool isCheck = memberService.CheckLogin(userName, password, ref msg);

            if (isCheck)
            {
                string roleData = memberService.GetRole(userName);
                var ticket = new FormsAuthenticationTicket
                    (
                        version:1,
                        name:userName,
                        issueDate: DateTime.Now,
                        expiration: DateTime.Now.AddMinutes(20),
                        isPersistent: false,
                        userData: roleData,
                        cookiePath: FormsAuthentication.FormsCookiePath
                    );
                //將資料加密成字串
                string enTicket = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName,enTicket));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", msg);
                return View(loginMember);
            }

        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            //判斷使用者是否已經登入驗證
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register(MemberRegisterViewModel registerMember)
        {
            if (!ModelState.IsValid)
            {
                registerMember.CheckPassword = "";
                registerMember.Password = "";
                return View(registerMember);
            }
            else
            {
                
                registerMember.NewMember.Password = registerMember.Password;
                registerMember.NewMember.AuthCode= mailService.GetValidateCode();
                memberService.Register(registerMember.NewMember);
                return RedirectToAction("RegisterResult");
            }         
        }
        public ActionResult RegisterResult()
        {
            return View();
        }
    }
}