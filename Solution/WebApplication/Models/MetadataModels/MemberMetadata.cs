using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApplication.Models
{
    [MetadataType(typeof(MemberMetadata))]
    public partial class Member
    {
        public class MemberMetadata
        {
            [Display(Name="帳號")]
            [Required(ErrorMessage ="請輸入帳號")]
            [StringLength(30,MinimumLength =6,ErrorMessage ="帳號長度需介於{0}~{2}字元")]
            [Remote("AccountCheck","Member",ErrorMessage ="此帳號已經被註冊過")]
            public string Account { get; set; }
            [DataType(DataType.Password)]
            public string Password { get; set; }
            [Display(Name = "姓名")]
            [StringLength(20, MinimumLength = 6, ErrorMessage = "帳號長度需介於{0}~{2}字元")]
            public string Name { get; set; }
            [Display(Name = "Email")]
            [Required(ErrorMessage = "請輸入Email")]
            [StringLength(200, MinimumLength = 6, ErrorMessage = "帳號長度需介於{0}~{2}字元")]
            [EmailAddress(ErrorMessage ="非Email格式")]
            public string Email { get; set; }
            public string AuthCode { get; set; }
            public bool IsAdmin { get; set; }
        }

    }
}