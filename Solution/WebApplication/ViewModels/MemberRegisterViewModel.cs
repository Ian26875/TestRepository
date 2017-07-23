using System.ComponentModel.DataAnnotations;

namespace WebApplication.ViewModels
{
    /// <summary>
    /// 會員註冊ViewModel
    /// </summary>
    public class MemberRegisterViewModel
    {
        public Models.Member NewMember { get; set; }
        [Display(Name ="密碼")]   
        [Required(ErrorMessage = "請輸入密碼")]
        public string Password { get; set; }
        [Display(Name = "確認密碼")]
        [Required(ErrorMessage = "請輸入確認密碼")]
        [Compare("Password", ErrorMessage ="兩次輸入密碼不一致")]
        public string CheckPassword { get; set; }
    }
}