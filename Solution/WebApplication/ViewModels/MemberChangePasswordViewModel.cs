using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.ViewModels
{
    /// <summary>
    /// 修改密碼ViewModel
    /// </summary>
    public class MemberChangePasswordViewModel
    {
        [Display(Name = "舊密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        public string Password { get; set; }
        [Display(Name = "新密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        public string NewPassword { get; set; }

        [Display(Name = "新密碼確認")]
        [Required(ErrorMessage = "請輸入密碼")]
        [Compare("NewPassword", ErrorMessage = "兩次輸入密碼不一致")]
        public string NewPasswordCheck { get; set; }
    }
}