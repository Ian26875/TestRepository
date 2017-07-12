using HomeWorkDB.Attribute;
using System.ComponentModel.DataAnnotations;

namespace HomeWorkDB.Models.ViewModels
{
    public class LoginViewModel
    {
        [StringLength(20,MinimumLength =4)]
        [Display(Name ="密碼")]
        public string Password { get; set; }
        [Display(Name ="帳號")]
        [EmailAddress]
        [BanWord("skilltree,demo,twMVC")]
        public string Account { get; set; }
    }
}