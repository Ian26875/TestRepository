using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.ViewModels
{
    /// <summary>
    /// 登入用ViewModel
    /// </summary>
    public class MemberLoginViewModel
    {
        [Display(Name ="會員帳號")]
        [Required]
        public string UserName { get; set; }
        [Display(Name ="會員密碼")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}