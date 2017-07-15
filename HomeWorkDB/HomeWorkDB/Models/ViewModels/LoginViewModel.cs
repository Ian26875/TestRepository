using HomeWorkDB.Attribute;
using System.ComponentModel.DataAnnotations;

namespace HomeWorkDB.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(20,MinimumLength =4)]
        [Display(Name ="密碼")]
        public string Password { get; set; }
        [Required]
        [Display(Name ="帳號")]
        [EmailAddress]
        [BanWord("skilltree","demo","twMVC",ErrorMessage = "不能輸入skilltree,demo,twMVC字串")]
        public string Account { get; set; }
    }
}